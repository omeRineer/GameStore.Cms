using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Domain.Core
{
    public class SliderContentModel
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public GetMediaModel CoverImage { get; set; }
    }
}
