using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Cms.Models.Domain.Core;

namespace GameStore.Cms.Models.Rest.Game
{
    public class GetGameImagesModel
    {
        public List<GetMediaModel>? Images { get; set; }
    }
}
