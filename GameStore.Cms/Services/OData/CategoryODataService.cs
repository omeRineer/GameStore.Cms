using GameStore.Cms.Models.OData;
using GameStore.Cms.Services.Base;
using Radzen;
using RestSharp;

namespace GameStore.Cms.Services.OData
{
    public class CategoryODataService : BaseODataService<ODataCategory>
    {
        public CategoryODataService() : base("Categories") { }
    }
}
