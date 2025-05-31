using System.Net.Http;

namespace GameStore.Cms.Services.Internal
{
    public class MaterialconService
    {
        public List<KeyValuePair<string, string>>? Icons { get; private set; }

        public async Task<List<KeyValuePair<string, string>>> GetIcons()
        {
            if (Icons != null)
                return Icons;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(CmsConfiguration.HostEnvironment.BaseAddress) })
            {
                var stringResponse = await httpClient.GetStringAsync("assets/material-icons.codepoints");

                var icons = stringResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                           .Select(line => line.Trim())
                           .Where(line => line.Contains(' '))
                           .Select(line =>
                           {
                               var parts = line.Split(' ');
                               return new KeyValuePair<string, string>(parts[0], parts[1]);
                           });

                Icons = icons.ToList();

                return Icons;
            }
        }
    }
}
