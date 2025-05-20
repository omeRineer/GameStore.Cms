using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.ProcessGroups;
using Radzen;
using GameStore.Cms.Models.OData;

namespace GameStore.Cms.Services.OData
{
    public class TypeLookupODataService : BaseODataService<ODataMenu>
    {
        public TypeLookupODataService() : base("TypeLookups") { }
    }
}
