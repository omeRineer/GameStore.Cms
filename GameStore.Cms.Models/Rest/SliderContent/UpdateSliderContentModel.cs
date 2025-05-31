using GameStore.Cms.Models.Inputs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.SliderContent
{
    public class UpdateSliderContentModel
    {
        public Guid Id { get; set; }

        [Required]
        public int SliderTypeId { get; set; }

        public string? Header { get; set; }

        public string? To { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public int Priority { get; set; }

        public Common.File Image { get; set; }
    }
}
