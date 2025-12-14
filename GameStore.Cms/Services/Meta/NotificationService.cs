using GameStore.Cms.Models.Enums;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using GameStore.Cms.Services.Internal;

namespace GameStore.Cms.Services.Meta
{
    public class NotificationService
    {
        readonly CurrentUserService currentUserService;
        readonly HttpClientService _httpClientService;

        public NotificationService(HttpClientService httpClientService, CurrentUserService currentUserService)
        {
            _httpClientService = httpClientService;
            this.currentUserService = currentUserService;
        }

        public async Task<DataResponseModel<TModel>> GetListAsync<TModel>()
        {
            var user = await currentUserService.GetCurrentUserAsync();

            return await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.FluxifyOptions.ApiUrl}/notifications", new Dictionary<string, object>
            {
                { ClaimTypes.FluxifyApiKey, user.Claims[ClaimTypes.FluxifyApiKey] }
            });
        }

        public async Task<DataResponseModel<TModel>> ReadAsync<TModel>(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/metaapi/Notifications/{id}?Notification-Api-Key=z4s6pKl3ztfDcBlg1du5rRZmdylG7q5oAjtcUhpSd6K2GpZQfD4awicKbm2RNCDe");

    }
}
