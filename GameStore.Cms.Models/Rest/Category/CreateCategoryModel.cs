using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Category
{
    public class CreateCategoryModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
