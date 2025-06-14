using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Identity.Permission
{
    public class UpdatePermissionModel
    {
        public Guid Id { get; set; }

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
