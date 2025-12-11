using GameStore.Cms.Models.Rest;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Internal;
using RestSharp;

namespace GameStore.Cms.Services.Base
{
    public class CrudService
    {
        protected readonly HttpClientService _httpClientService;
        protected readonly string Controller;
        public CrudService(string controller)
        {
            Controller = controller;
            _httpClientService = StaticServiceProvider.GetService<HttpClientService>();
        }

        public async Task<DataResponseModel<TModel>> GetListAsync<TModel>()
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}");

        public async Task<DataResponseModel<TModel>> GetAsync<TModel>(object id)
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/{id}");

        public async Task<ResponseModel> CreateAsync(object entity)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/Create", entity);

        public async Task<ResponseModel> DeleteAsync(object id)
            => await _httpClientService.DeleteAsync<ResponseModel>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/Delete/{id}");

        public async Task<ResponseModel> UpdateAsync(object entity)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/Update", entity);


    }
}
