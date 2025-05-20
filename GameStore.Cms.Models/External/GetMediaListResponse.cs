using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.External
{
    public class StorageResult
    {
        public int Count { get; set; }
        public string Node { get; set; }
        public List<MediaItem> Files { get; set; }
    }

    public class MediaItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }
}
