using GameStore.Cms.Models.Category;
using GameStore.Cms.Models.Identity.Permission;
using GameStore.Cms.Models.Identity.Role;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master.Identity
{
    public class PermissionService : BaseService
    {
        public PermissionService() : base("Permissions") { }
    }
}
