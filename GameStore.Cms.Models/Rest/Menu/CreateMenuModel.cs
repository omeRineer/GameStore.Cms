using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Menu
{
    public class CreateMenuModel
    {
        public Guid? ParentMenuId { get; set; }

        [MaxLength(5)]
        public string? Code { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }
        public int? Priority { get; set; }

        [MaxLength(50)]
        public string? Path { get; set; }

        [MaxLength(30)]
        public string? Icon { get; set; }
    }
}
