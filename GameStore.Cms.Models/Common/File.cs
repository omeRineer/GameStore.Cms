using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Common
{
    public class File
    {
        public string Path => $"/{Node}/{Name}";
        public string Name { get; set; }
        public string? Node { get; set; }
    }
}
