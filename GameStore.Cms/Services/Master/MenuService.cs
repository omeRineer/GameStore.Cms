using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Menu;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class MenuService : BaseService
    {
        public MenuService() : base("Menus") { }

        public async Task<DataResponseModel<GetMenusModel>> GetSessionMenusAsync()
            => await _httpClientService.GetAsync<DataResponseModel<GetMenusModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/SessionMenus");

        public async Task<ResponseModel> SetPermissionsAsync(SetMenuPermissionsModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/SetPermissions", model);

        public async Task<DataResponseModel<GetMenuPermissionsModel>> GetPermissionsAsync(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<GetMenuPermissionsModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/GetPermissions/{id}");
    }
}
