using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Identity.Role;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master.Identity
{
    public class RoleService : CrudService
    {
        public RoleService() : base("Roles") { }

        public async Task<ResponseModel> SetPermissionsAsync(SetRolePermissionsModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.BaseUrl}/identityapi/{Controller}/SetPermissions", model);

        public async Task<DataResponseModel<GetRolePermissionsModel>> GetPermissionsAsync(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<GetRolePermissionsModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/identityapi/{Controller}/GetPermissions/{id}");

    }
}
