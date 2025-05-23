using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Identity.User
{
    public class GetUserPermissionsModel
    {
        public List<Guid>? Permissions { get; set; }
    }
}
