using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Menu;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class MenuService : CrudService
    {
        public MenuService() : base("Menus") { }

        public async Task<DataResponseModel<GetMenusModel>> GetSessionMenusAsync()
            => await _httpClientService.GetAsync<DataResponseModel<GetMenusModel>>($"{CmsConfiguration.APIOptions.BaseUrl}/internalapi/{Controller}/SessionMenus");

    }
}
