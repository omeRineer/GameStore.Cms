using GameStore.Cms.Models.Inputs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.SliderContent
{
    public class CreateSliderContentModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen geçerli bir değer giriniz!")]
        [DefaultValue(-1)]
        public int SliderTypeId { get; set; }

        [MaxLength(30)]
        public string? Header { get; set; }

        [MaxLength(100)]
        public string? To { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public int Priority { get; set; }

        [Required]
        public Common.File Image { get; set; }
    }
}
