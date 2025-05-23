using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Identity.Role;
using GameStore.Cms.Models.Identity.User;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master.Identity
{
    public class UserService : BaseService
    {
        public UserService() : base("Users") { }

        public async Task<ResponseModel> SetPermissionsAsync(SetUserPermissionsModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/SetPermissions", model);

        public async Task<DataResponseModel<GetUserPermissionsModel>> GetPermissionsAsync(Guid userId)
            => await _httpClientService.GetAsync<DataResponseModel<GetUserPermissionsModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/GetPermissions/{userId}");


        public async Task<ResponseModel> SetRolesAsync(SetUserRolesModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/SetRoles", model);

        public async Task<DataResponseModel<GetUserRolesModel>> GetRolesAsync(Guid userId)
            => await _httpClientService.GetAsync<DataResponseModel<GetUserRolesModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/GetRoles/{userId}");

    }
}
