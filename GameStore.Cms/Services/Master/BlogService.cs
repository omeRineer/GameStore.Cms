using GameStore.Cms.Services.Base;
using RestSharp;
using GameStore.Cms.Models.Blog;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class BlogService : BaseService
    {
        public BlogService() : base("Blogs") { }
    }
}
