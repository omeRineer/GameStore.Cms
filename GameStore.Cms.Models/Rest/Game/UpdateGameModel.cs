using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Game
{
    public class UpdateGameModel
    {
        public Guid Id { get; set; }

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
