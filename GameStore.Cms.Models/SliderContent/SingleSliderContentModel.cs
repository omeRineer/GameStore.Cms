using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.SliderContent
{
    public class SingleSliderContentModel
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public Common.File Image { get; set; }

        public SingleSliderContentTypeModel SliderType { get; set; }
    }

    public class SingleSliderContentTypeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
