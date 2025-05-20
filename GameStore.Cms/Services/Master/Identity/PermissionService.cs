using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master.Identity
{
    public class PermissionService : BaseService
    {
        public PermissionService() : base("Permissions") { }

        public async Task<RestResponse> CreateAsync(CreateCategoryModel model)
            => await base.CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateCategoryModel model)
            => await base.UpdateAsync(model);

        public async Task<RestResponse<DataResponseModel<SingleCategoryModel>>> GetAsync(Guid id)
            => await base.GetAsync<Guid, DataResponseModel<SingleCategoryModel>>(id);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await base.DeleteAsync(id);
    }
}
