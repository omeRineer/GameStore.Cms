using Blazored.LocalStorage;
using Core.Utilities.RestHelper;
using Core.Utilities.ResultTool;
using Core.Utilities.ServiceTools;
using GameStore.Cms.Models.Identity;
using GameStore.Cms.Services.Internal;
using RestSharp;

namespace GameStore.Cms.Services.Base
{
    public class BaseService
    {
        protected readonly ILocalStorageService LocalStorageService;
        protected readonly string Controller;
        public BaseService(string controller)
        {
            Controller = controller;
            LocalStorageService = StaticServiceProvider.GetService<ILocalStorageService>();
        }

        protected async Task<RestResponse<TModel>> GetAsync<TKey, TModel>(TKey id)
            => await RestHelper.GetAsync<TModel>(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/{id}",
            });

        protected async Task<RestResponse> CreateAsync<TModel>(TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/create",
                Authorization = $"Bearer {await LocalStorageService.GetItemAsync<string>("AUTH_TOKEN")}"
            }, entity);

        protected async Task<RestResponse> DeleteAsync<TKey>(TKey id)
            => await RestHelper.DeleteAsync(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/delete/{id}"
            });

        protected async Task<RestResponse> UpdateAsync<TModel>(TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/update"
            }, entity);

    }
}
