using KPMG.Processor;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Processor
{
    public interface ICosmosDbMetadata
    {
        Task<DatabaseAccountListKeyResults> GetAccountSettingsAsync(CancellationToken cancellationToken);
    }

    public class CosmosDbMetadata : ICosmosDbMetadata
    {
        private readonly HttpClient _cosmosHttpClient;
        private readonly CosmosDbSettings _cosmosDbSettings;

        public CosmosDbMetadata(HttpClient httpClient, CosmosDbSettings cosmosDbSettings)
        {
            _cosmosHttpClient = httpClient;
            _cosmosDbSettings = cosmosDbSettings;
        }

        public async Task<DatabaseAccountListKeyResults> GetAccountSettingsAsync(CancellationToken cancellationToken)
        {
            var requestUri = $"{_cosmosDbSettings.DatabaseResourceId}{_cosmosDbSettings.PostFixUrl}";

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            DatabaseAccountListKeyResults metadataResult = null;

            using (var response = await _cosmosHttpClient.SendAsync(request, cancellationToken))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    metadataResult = JsonConvert.DeserializeObject<DatabaseAccountListKeyResults>(responseContent);
                }
                else
                {
                    throw new Exception($"Failed to get the metadata. Status Code : {response.StatusCode}. Response Phrase: {response.ReasonPhrase}");
                }
            }

            return metadataResult;
        }
    }
}
