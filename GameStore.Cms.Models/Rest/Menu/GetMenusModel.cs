using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Menu
{
    public class GetMenusModel
    {
        public List<GetMenus_Item>? Menus { get; set; }
    }

    public class GetMenus_Item
    {
        public Guid Id { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string Icon { get; set; }
    }
}
