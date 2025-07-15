using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;

namespace GameStore.Cms.Models.Rest.Game
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<PostMediaModel> Images { get; set; }
    }
}
