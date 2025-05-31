using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Category
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
