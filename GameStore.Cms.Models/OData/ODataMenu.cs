using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.OData
{
    public class ODataMenu : ODataModel<Guid>
    {
        public Guid? ParentMenuId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string Icon { get; set; }

        public ODataMenu? ParentMenu { get; set; }
    }
}
