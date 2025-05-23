using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Identity.Role
{
    public class SetRolePermissionsModel
    {
        public Guid RoleId { get; set; }
        public List<Guid>? Permissions { get; set; }
    }
}
