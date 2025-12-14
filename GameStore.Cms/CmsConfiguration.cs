using GameStore.Cms.Options;
using GameStore.Cms.Options.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace GameStore.Cms
{
    public static class CmsConfiguration
    {
        static Settings Settings;
        public static async Task InitializeAsync(string env, HttpClient httpClient)
        {
            Settings = await httpClient.GetFromJsonAsync<Settings>($"config/appsettings.{env}.json?v={DateTime.Now.Ticks}")
                       ?? throw new Exception($"appsettings.{env}.json Not Found");
        }

        public static APIOptions APIOptions { get => Settings.APIOptions; }
        public static FluxifyOptions FluxifyOptions { get => Settings.FluxifyOptions; }
        public static HostEnvironment HostEnvironment { get => Settings.HostEnvironment; }

    }
}
