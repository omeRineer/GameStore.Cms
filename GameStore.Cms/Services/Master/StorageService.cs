using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Storage;
using GameStore.Cms.Services.Base;

namespace GameStore.Cms.Services.Master
{
    public class StorageService : CrudService
    {
        public StorageService() : base("Storage")
        {
        }

        public async Task<DataResponseModel<GetFilesModel>> GetFilesAsync(string? tags = null)
            => await _httpClientService.GetAsync<DataResponseModel<GetFilesModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/GetFiles/{tags}");

    }
}
