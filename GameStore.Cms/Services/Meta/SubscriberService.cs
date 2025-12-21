using GameStore.Cms.Models.Domain.Meta;
using GameStore.Cms.Models.Enums;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Internal;

namespace GameStore.Cms.Services.Meta
{
    public class SubscriberService
    {
        readonly CurrentUserService currentUserService;
        readonly HttpClientService _httpClientService;

        public SubscriberService(HttpClientService httpClientService, CurrentUserService currentUserService)
        {
            _httpClientService = httpClientService;
            this.currentUserService = currentUserService;
        }

        public async Task<DataResponseModel<List<SubscriberModel>>> GetListAsync()
        {
            var user = await currentUserService.GetCurrentUserAsync();

            return await _httpClientService.GetAsync<DataResponseModel<List<SubscriberModel>>>($"{CmsConfiguration.FluxifyOptions.ApiUrl}/subscribers", new Dictionary<string, object>
            {
                { ClaimTypes.FluxifyApiKey, user.Claims[ClaimTypes.FluxifyApiKey] }
            });
        }


    }
}
