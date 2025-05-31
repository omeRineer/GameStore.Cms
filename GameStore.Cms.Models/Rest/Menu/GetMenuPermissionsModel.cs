using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Menu
{
    public class GetMenuPermissionsModel
    {
        public List<Guid>? Permissions { get; set; }
    }
}
