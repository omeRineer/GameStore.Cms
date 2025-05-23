using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Identity.Role
{
    public class GetRolePermissionsModel
    {
        public List<Guid>? Permissions { get; set; }
    }
}
