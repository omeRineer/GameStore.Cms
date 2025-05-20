using GameStore.Cms.Models.OData.Identity;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.OData.Identity
{
    public class PermissionODataService : BaseODataService<ODataPermission>
    {
        public PermissionODataService() : base("Permissions") { }
    }
}
