using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.OData
{
    public class ODataCategory : ODataModel<Guid>
    {
        public string Name { get; set; }

        public ICollection<ODataGame> Games { get; set; }
    }
}
