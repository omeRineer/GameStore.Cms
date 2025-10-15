using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;

namespace GameStore.Cms.Models.Rest.Game
{
    public class UploadGameImagesModel
    {
        public Guid EntityId { get; set; }
        public List<UploadGameImages_Item> Images { get; set; }

        public class UploadGameImages_Item
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public int Priority { get; set; }
        }
    }
}
