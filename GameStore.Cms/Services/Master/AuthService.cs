
using Core.Utilities.RestHelper;
using GameStore.Cms.Models.Auth;
using GameStore.Cms.Models.Blog;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class AuthService : BaseService
    {
        public AuthService() : base("Auth") { }

        public async Task<RestResponse<DataResponseModel<AccessTokenModel>>> LoginAsync(UserLoginModel model)
            => await RestHelper.PostAsync<UserLoginModel, DataResponseModel<AccessTokenModel>>(new RestRequestParameter
            {
                BaseUrl = $"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}/Login"
            }, model);
    }
}
