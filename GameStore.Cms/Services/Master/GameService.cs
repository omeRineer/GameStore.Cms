using GameStore.Cms.Services.Base;
using Core.Utilities.RestHelper;
using RestSharp;
using GameStore.Cms.Models.Game;
using GameStore.Cms.Models.Blog;
using GameStore.Cms.Models.Rest;

namespace GameStore.Cms.Services.Master
{
    public class GameService : BaseService
    {
        public GameService() : base("Games") { }

        public async Task<RestResponse> UploadGameImagesAsync(UploadGameImagesModel uploadGameImagesModel)
            => await RestHelper.PostAsync<UploadGameImagesModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/UploadImages"
            }, uploadGameImagesModel);

        public async Task<RestResponse<DataResponseModel<SingleGameModel>>> GetAsync(Guid id)
            => await base.GetAsync<Guid, DataResponseModel<SingleGameModel>>(id);

        public async Task<RestResponse> CreateAsync(CreateGameModel model)
            => await base.CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateGameModel model)
            => await base.UpdateAsync(model);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await base.DeleteAsync(id);
    }
}
