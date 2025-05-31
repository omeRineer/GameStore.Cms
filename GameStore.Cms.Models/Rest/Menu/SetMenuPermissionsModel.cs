using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Menu
{
    public class SetMenuPermissionsModel
    {
        public Guid MenuId { get; set; }
        public List<Guid>? Permissions { get; set; }
    }
}
