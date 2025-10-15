using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Game
{
    public class CreateGameModel
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        
        public string? Content { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string? CoverImage { get; set; }
    }
}
