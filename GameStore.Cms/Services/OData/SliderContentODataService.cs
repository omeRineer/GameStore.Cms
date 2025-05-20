using GameStore.Cms.Models.OData;
using GameStore.Cms.Services.Base;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class SliderContentODataService : BaseODataService<ODataSliderContent>
    {
        public SliderContentODataService() : base("SliderContents") { }
    }
}
