using GameStore.Cms.Models.OData.Identity;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.OData.Identity
{
    public class RoleODataService : BaseODataService<ODataRole>
    {
        public RoleODataService() : base("Roles") { }
    }
}
