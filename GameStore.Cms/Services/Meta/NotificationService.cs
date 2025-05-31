using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using GameStore.Cms.Services.Internal;

namespace GameStore.Cms.Services.Meta
{
    public class NotificationService
    {
        readonly HttpClientService _httpClientService;

        public NotificationService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<DataResponseModel<TModel>> GetListAsync<TModel>()
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.Meta.ApiUrl}/Notifications");

        public async Task<DataResponseModel<TModel>> ReadAsync<TModel>(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.Meta.ApiUrl}/Notifications/{id}");

    }
}
