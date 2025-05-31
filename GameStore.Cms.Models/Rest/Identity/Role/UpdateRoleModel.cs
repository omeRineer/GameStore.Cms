using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Identity.Role
{
    public class UpdateRoleModel
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[^@#!\s]*$", ErrorMessage = "Boşluk, '@', '#', '!' karakterleri kullanılamaz.")]
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
