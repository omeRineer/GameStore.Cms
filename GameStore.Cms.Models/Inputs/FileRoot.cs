using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Inputs
{
    public class FileRoot
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string FileId { get; set; }

        public List<string> Tags { get; set; }

        public bool IsPrivateFile { get; set; }

        public string Url { get; set; }

        public string Thumbnail { get; set; }

        public string FileType { get; set; }

        public string FilePath { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Size { get; set; }

        public bool HasAlpha { get; set; }

        public string Mime { get; set; }
    }
}
