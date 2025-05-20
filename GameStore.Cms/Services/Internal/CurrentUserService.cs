using Blazored.LocalStorage;
using GameStore.Cms.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GameStore.Cms.Services.Internal
{
    public class CurrentUserService
    {
        readonly ILocalStorageService LocalStorageService;
        CurrentUser CurrentUser;
        readonly AuthenticationStateProvider AuthenticationStateProvider;

        public CurrentUserService(AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
        {
            AuthenticationStateProvider = authenticationStateProvider;
            LocalStorageService = localStorageService;
        }

        public async Task<CurrentUser> GetCurrentUserAsync()
        {
            if (CurrentUser != null)
                return CurrentUser;

            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var claimsPrincipal = state.User;

            if (claimsPrincipal.Identity?.IsAuthenticated != true)
                return new CurrentUser
                {
                    IsAuthenticated = false
                };

            var claims = claimsPrincipal.Claims;

            CurrentUser = new CurrentUser
            {
                Id = Guid.Parse(claims.SingleOrDefault(f => f.Type == ClaimTypes.NameIdentifier).Value),
                Name = claims.SingleOrDefault(f => f.Type == ClaimTypes.Name)?.Value,
                Phone = claims.SingleOrDefault(f => f.Type == ClaimTypes.MobilePhone)?.Value,
                Email = claims.SingleOrDefault(f => f.Type == ClaimTypes.Email)?.Value,
                Roles = claims.Where(f => f.Type == ClaimTypes.Role).Select(s => s.Value).ToArray(),
                Permissions = claims.Where(f => f.Type == "Permission").Select(s => s.Value).ToArray(),
                IsAuthenticated = true
            };

            return CurrentUser;
        }
        public async Task LogoutAsync()
        {
            await LocalStorageService.RemoveItemAsync("AUTH_TOKEN");
            CurrentUser = null;
        }
    }
}
