using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Domain
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Common.File CoverImage { get; set; }

        public GameModel_Category Category { get; set; }
    }

    public class GameModel_Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
