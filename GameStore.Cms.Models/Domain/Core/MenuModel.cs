using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Domain.Core
{
    public class MenuModel
    {
        public Guid Id { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string? Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }
        public string? Permission { get; set; }
    }
}
