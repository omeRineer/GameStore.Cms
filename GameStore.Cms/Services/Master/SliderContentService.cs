using GameStore.Cms.Services.Base;
using Core.Utilities.RestHelper;
using RestSharp;
using GameStore.Cms.Models.SliderContent;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class SliderContentService : BaseService
    {
        public SliderContentService() : base("SliderContents") { }

        public async Task<RestResponse> CreateAsync(CreateSliderContentModel sliderContentCreateModel)
            => await base.CreateAsync(sliderContentCreateModel);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await base.DeleteAsync(id);

        public async Task<RestResponse> UpdateAsync(UpdateSliderContentModel model)
            => await base.UpdateAsync(model);

        public async Task<RestResponse<DataResponseModel<SingleSliderContentModel>>> GetAsync(Guid id)
            => await base.GetAsync<Guid, DataResponseModel<SingleSliderContentModel>>(id);
    }
}
