using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.Menu;
using Radzen;
using GameStore.Cms.Models.OData;

namespace GameStore.Cms.Services.OData
{
    public class MenuODataService : BaseODataService<ODataMenu>
    {
        public MenuODataService() : base("Menus") { }
    }
}
