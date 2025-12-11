using GameStore.Cms.Models.OData;
using Radzen;
using RestSharp;
using System.Net.Http.Json;

namespace GameStore.Cms.Services.Base
{
    public struct ODataRequestParams
    {
        public string? Filter { get; set; }
        public string? Select { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public string? OrderBy { get; set; }
        public string? Expand { get; set; }
        public bool? Count { get; set; }
    }

    public class BaseODataService<TModel>
    {
        readonly HttpClient HttpClient;
        protected readonly string Controller;

        public BaseODataService(string controller)
        {
            HttpClient = new HttpClient();
            Controller = controller;
        }

        public async Task<ODataServiceResult<TModel>> GetListAsync(ODataRequestParams requestParams)
        {
            var uri = new Uri($"{CmsConfiguration.APIOptions.BaseUrl}/odataapi/{Controller}");
            var oDataUri = uri.GetODataUri(requestParams.Filter,
                                    requestParams.Top,
                                    requestParams.Skip,
                                    requestParams.OrderBy,
                                    requestParams.Expand,
                                    requestParams.Select,
                                    requestParams.Count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, oDataUri);

            var response = await HttpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<TModel>>();
        }
    }
}
