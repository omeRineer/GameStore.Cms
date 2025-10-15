using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Blog
{
    public class CreateBlogModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Header { get; set; }

        [Required]
        [MinLength(100)]
        public string Content { get; set; }

        public bool Status { get; set; }

        public string? CoverImage { get; set; }
    }
}
