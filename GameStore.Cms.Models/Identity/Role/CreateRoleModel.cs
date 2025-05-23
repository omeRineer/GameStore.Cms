using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Identity.Role
{
    public class CreateRoleModel
    {
        [Required]
        [RegularExpression(@"^[^@#!\s]*$", ErrorMessage = "Boşluk, '@', '#', '!' karakterleri kullanılamaz.")]
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
