
using GameStore.Cms.Models.Inputs;

namespace GameStore.Cms.Models.Game
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<Common.File> Images { get; set; }
    }
}
