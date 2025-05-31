using GameStore.Cms.Models.Rest;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Internal;
using RestSharp;

namespace GameStore.Cms.Services.Base
{
    public class BaseService
    {
        protected readonly HttpClientService _httpClientService;
        protected readonly string Controller;
        public BaseService(string controller)
        {
            Controller = controller;
            _httpClientService = StaticServiceProvider.GetService<HttpClientService>();
        }

        public async Task<DataResponseModel<TModel>> GetListAsync<TModel>()
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}");

        public async Task<DataResponseModel<TModel>> GetAsync<TModel>(object id)
            => await _httpClientService.GetAsync<DataResponseModel<TModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/{id}");

        public async Task<ResponseModel> CreateAsync(object entity)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/Create", entity);

        public async Task<ResponseModel> DeleteAsync(object id)
            => await _httpClientService.DeleteAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/Delete/{id}");

        public async Task<ResponseModel> UpdateAsync(object entity)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/Update", entity);


    }
}
