using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Game;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.Master
{
    public class GameService : CrudService
    {
        public GameService() : base("Games") { }

        public async Task<ResponseModel> UploadImagesAsync(UploadGameImagesModel uploadGameImagesModel)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/UploadImages", uploadGameImagesModel);

        public async Task<DataResponseModel<ListResponseModel<GameImageModel>>> GetImagesAsync(Guid id)
            => await _httpClientService.GetAsync<DataResponseModel<ListResponseModel<GameImageModel>>>($"{CmsConfiguration.APIOptions.ApiUrl}/{Controller}/GetImages/{id}");

    }
}
