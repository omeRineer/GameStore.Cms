using GameStore.Cms.Models.Inputs;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Blog
{
    public class UpdateBlogModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        [MinLength(100)]
        public string Content { get; set; }

        public bool Status { get; set; }

        [Required]
        public Common.File? CoverImage { get; set; }
    }
}
