using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Identity.User;
using GameStore.Cms.Services.Base;

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


        public async Task<ResponseModel> SetClaimsAsync(SetUserClaimsModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/SetClaims", model);

        public async Task<DataResponseModel<GetUserClaimsModel>> GetClaimsAsync(Guid userId)
            => await _httpClientService.GetAsync<DataResponseModel<GetUserClaimsModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/GetClaims/{userId}");

    }
}
