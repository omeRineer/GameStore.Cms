using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Category
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}
