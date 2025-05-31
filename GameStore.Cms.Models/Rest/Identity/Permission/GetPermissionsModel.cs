using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Cms.Models.Domain.Core;

namespace GameStore.Cms.Models.Rest.Identity.Permission
{
    public class GetPermissionsModel
    {
        public List<PermissionModel>? Permissions { get; set; }
    }

}
