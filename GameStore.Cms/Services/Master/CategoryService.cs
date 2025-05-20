using GameStore.Cms.Services.Base;
using Core.Utilities.ResultTool;
using RestSharp;
using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class CategoryService : BaseService
    {
        public CategoryService() : base("Categories") { }

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
