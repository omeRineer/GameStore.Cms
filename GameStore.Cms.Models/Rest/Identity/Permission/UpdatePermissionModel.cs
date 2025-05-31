using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Identity.Permission
{
    public class UpdatePermissionModel
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[^@#!\s]*$", ErrorMessage = "Boşluk, '@', '#', '!' karakterleri kullanılamaz.")]
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
