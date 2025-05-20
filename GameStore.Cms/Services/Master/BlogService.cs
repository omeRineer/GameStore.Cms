using GameStore.Cms.Services.Base;
using Core.Utilities.RestHelper;
using RestSharp;
using GameStore.Cms.Models.Blog;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class BlogService : BaseService
    {
        public BlogService() : base("Blogs") { }

        public async Task<RestResponse<DataResponseModel<SingleBlogModel>>> GetAsync(Guid id)
            => await base.GetAsync<Guid, DataResponseModel<SingleBlogModel>>(id);

        public async Task<RestResponse> CreateAsync(CreateBlogModel model)
            => await base.CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateBlogModel model)
            => await base.UpdateAsync(model);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await base.DeleteAsync(id);
    }
}
