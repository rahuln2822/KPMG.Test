using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KPMG.Processor
{
    public class AzureAuthHandler : DelegatingHandler
    {
        private const string ResourceUrl = "https://management.azure.com/";
        private readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        public AzureAuthHandler(AzureServiceTokenProvider azureServiceTokenProvider)
        {
            _azureServiceTokenProvider = azureServiceTokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            if(message == null) 
                throw new ArgumentNullException(nameof(message));

            var accessToken = await _azureServiceTokenProvider.GetAccessTokenAsync(ResourceUrl);

            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            return await base.SendAsync(message, cancellationToken);
        }
    }
}
