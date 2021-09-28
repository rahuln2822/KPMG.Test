using FluentAssertions;
using Processor;
using System;
using System.Threading;
using Xunit;

namespace KPMG.Test.IntegrationTests
{
    public class CosmosDbMetadataShould : DependencyFixture
    {
        private readonly ICosmosDbMetadata _cosmosDbMetadata;
        public CosmosDbMetadataShould()
        {
            _cosmosDbMetadata = (ICosmosDbMetadata)ServiceProvider.GetService(typeof(ICosmosDbMetadata));
        }

        [Fact]
        public void ConnectToAzure_WhenGetAccountSettingsAsyncIsCalled()
        {
            //Given 
            //Appropriate role is assigned to user

            //When
            var result = _cosmosDbMetadata.GetAccountSettingsAsync(CancellationToken.None).GetAwaiter().GetResult();

            //Then
            result.Should().NotBeNull();
        }
    }
}
