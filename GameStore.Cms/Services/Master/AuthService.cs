using GameStore.Cms.Models.Rest;
using GameStore.Cms.Models.Rest.Auth;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class AuthService : BaseService
    {
        public AuthService() : base("Auth") { }

        public async Task<DataResponseModel<AccessTokenModel>> LoginAsync(UserLoginModel model)
            => await _httpClientService.PostAsync<DataResponseModel<AccessTokenModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/Login", model);
    }
}
