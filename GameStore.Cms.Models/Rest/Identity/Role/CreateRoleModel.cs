using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Identity.Role
{
    public class CreateRoleModel
    {
        [Required]
        [RegularExpression(@"^[^@#!\s]*$", ErrorMessage = "Boşluk, '@', '#', '!' karakterleri kullanılamaz.")]
        public string Key { get; set; }

        [MinLength(10)]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
