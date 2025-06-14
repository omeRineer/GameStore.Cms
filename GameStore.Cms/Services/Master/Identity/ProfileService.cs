﻿using GameStore.Cms.Models.Rest.Identity.Role;
using GameStore.Cms.Models.Rest;
using GameStore.Cms.Services.Base;
using GameStore.Cms.Models.Rest.Identity.Profile;

namespace GameStore.Cms.Services.Master.Identity
{
    public class ProfileService : BaseService
    {
        public ProfileService() : base("Profile")
        {
        }

        public async Task<ResponseModel> UpdateAsync(UpdateProfileModel model)
            => await _httpClientService.PostAsync<ResponseModel>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}", model);

        public async Task<DataResponseModel<ProfileModel>> GetAsync()
            => await _httpClientService.GetAsync<DataResponseModel<ProfileModel>>($"{CmsConfiguration.APIOptions.Web.ApiUrl}/{Controller}");

    }
}
