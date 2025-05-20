using GameStore.Cms.Models.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Game
{
    public class UpdateGameModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Common.File? CoverImage { get; set; }
    }
}
