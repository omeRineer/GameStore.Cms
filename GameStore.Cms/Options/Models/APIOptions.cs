using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Options.Models
{
    public class APIOptions
    {
        public WebAPIOptions Web { get; set; }
        public ODataAPIOptions OData { get; set; }
        public MetaAPIOptions Meta { get; set; }
    }
    public class WebAPIOptions
    {
        public string ApiUrl { get; set; }
        public string BaseUrl { get; set; }
    }

    public class ODataAPIOptions
    {
        public string ApiUrl { get; set; }
        public string BaseUrl { get; set; }
    }

    public class MetaAPIOptions
    {
        public string ApiUrl { get; set; }
        public string BaseUrl { get; set; }
        public string HubApiKey { get; set; }
    }
}
