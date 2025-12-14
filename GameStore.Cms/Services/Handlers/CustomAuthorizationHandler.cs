using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace GameStore.Cms.Services.Handlers
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public readonly string[] Claims;

        public CustomAuthorizationRequirement(string requirements)
        {
            Claims = new string[] { "SuperAdmin" }
                                .Concat(requirements.Split(','))
                                .ToArray();
        }
    }
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            var user = context.User;

            if (user == null)
                return Task.CompletedTask;

            var userClaims = GetRolesAndPermissions(user);

            if (!userClaims.Any(x => requirement.Claims.Contains(x)))
                return Task.CompletedTask;

            context.Succeed(requirement);

            return Task.CompletedTask;
        }

        string[] GetRolesAndPermissions(ClaimsPrincipal user)
        {
            var claims = user.Claims.Where(f => f.Type == ClaimTypes.Role || f.Type == "Permission");

            var result = new List<string>();
            foreach (var claim in claims)
            {
                if (claim.Value.StartsWith('['))
                {
                    var deserializedValue = JsonSerializer.Deserialize<string[]>(claim.Value);

                    if (deserializedValue != null)
                        result = result.Concat(deserializedValue).ToList();
                }
                else
                    result.Add(claim.Value);
            }

            return result.ToArray();
        }
    }
}
