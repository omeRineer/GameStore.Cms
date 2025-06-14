using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Category
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
