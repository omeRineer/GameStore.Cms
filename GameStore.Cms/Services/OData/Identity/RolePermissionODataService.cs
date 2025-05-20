using GameStore.Cms.Models.OData.Identity;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.OData.Identity
{
    public class RolePermissionODataService : BaseODataService<ODataRolePermission>
    {
        public RolePermissionODataService() : base("RolePermissions") { }
    }
}
