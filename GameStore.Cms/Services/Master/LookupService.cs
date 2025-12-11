using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Lookups;
using GameStore.Cms.Services.Internal;

namespace GameStore.Cms.Services.Master
{
    public class LookupService
    {
        readonly HttpClientService _httpClientService;

        public LookupService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<DataResponseModel<GetLookupsModel>> GetSliderTypesAsync()
            => await _httpClientService.GetAsync<DataResponseModel<GetLookupsModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/Lookups/SliderTypes");
    }
}
