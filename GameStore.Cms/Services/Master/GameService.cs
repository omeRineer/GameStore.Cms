using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.Master
{
    public class GameService : BaseService
    {
        public GameService() : base("Games") { }

        //public async Task<RestResponse> UploadGameImagesAsync(UploadGameImagesModel uploadGameImagesModel)
        //    => await RestHelper.PostAsync<UploadGameImagesModel, object>(new RestRequestParameter
        //    {
        //        BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/UploadImages"
        //    }, uploadGameImagesModel);
    }
}
