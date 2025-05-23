using GameStore.Cms.Services.Base;
using RestSharp;
using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class CategoryService : BaseService
    {
        public CategoryService() : base("Categories") { }
    }
}
