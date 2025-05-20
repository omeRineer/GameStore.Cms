using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Game
{
    public class SingleGameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Common.File CoverImage { get; set; }

        public SingleGame_Category Category { get; set; }
    }

    public class SingleGame_Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
