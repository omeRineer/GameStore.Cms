using GameStore.Cms.Services.Base;
using Core.Utilities.RestHelper;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class MediaService : BaseService
    {
        public MediaService() : base("Medias") { }

        //public async Task<RestResponse> UploadMedia(UploadMediaModel mediaUploadModel)
        //    => await RestHelper.PostAsync<object, object>(new RestRequestParameter
        //    {
        //        BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/uploadmedia",
        //        QueryParameters = new Dictionary<string, object> { { "EntityId", mediaUploadModel.EntityId }, { "MediaTypeId", (int)MediaTypeEnum.GameImage } },
        //        Files = mediaUploadModel.MediaList.Select(s => new RestFile
        //        {
        //            Bytes = s.Bytes,
        //            FileName = s.FileName,
        //            Name = s.FileName
        //        }).ToList()
        //    });
    }
}
