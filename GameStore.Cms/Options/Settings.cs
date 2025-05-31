using GameStore.Cms.Options.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Options
{
    public class Settings
    {
        public APIOptions APIOptions { get; set; }
        public HostEnvironment HostEnvironment { get; set; }
    }
}
