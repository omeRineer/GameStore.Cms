using GameStore.Cms.Models.Domain.Core;
using GameStore.Cms.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Rest.Storage
{
    public class GetFilesModel
    {
        public List<FileRoot>? FileList { get; set; }
    }
}
