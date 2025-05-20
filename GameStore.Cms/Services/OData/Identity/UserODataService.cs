using GameStore.Cms.Models.OData.Identity;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.OData.Identity
{
    public class UserODataService : BaseODataService<ODataUser>
    {
        public UserODataService() : base("Users") { }
    }
}
