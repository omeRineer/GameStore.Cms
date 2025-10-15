using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Domain.Core
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? CoverImage { get; set; }

        public CategoryModel Category { get; set; }
    }
}
