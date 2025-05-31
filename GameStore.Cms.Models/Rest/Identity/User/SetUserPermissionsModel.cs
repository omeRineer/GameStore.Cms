using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Identity.User
{
    public class SetUserPermissionsModel
    {
        public Guid UserId { get; set; }
        public List<Guid>? Permissions { get; set; }
    }
}
