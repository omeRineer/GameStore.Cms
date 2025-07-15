using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Game;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.Master
{
    public class GameService : CrudService
    {
        public GameService() : base("Games") { }

        public async Task<ResponseModel> UploadImagesAsync(UploadGameImagesModel uploadGameImagesModel)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/UploadImages", uploadGameImagesModel);

        public async Task<DataResponseModel<GetGameImagesModel>> GetImagesAsync(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<GetGameImagesModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/GetImages/{id}");

    }
}
