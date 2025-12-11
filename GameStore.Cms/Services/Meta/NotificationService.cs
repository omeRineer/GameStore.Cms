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
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/metaapi/Notifications?Notification-Api-Key=z4s6pKl3ztfDcBlg1du5rRZmdylG7q5oAjtcUhpSd6K2GpZQfD4awicKbm2RNCDe");

        public async Task<DataResponseModel<TModel>> ReadAsync<TModel>(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/metaapi/Notifications/{id}?Notification-Api-Key=z4s6pKl3ztfDcBlg1du5rRZmdylG7q5oAjtcUhpSd6K2GpZQfD4awicKbm2RNCDe");

    }
}
