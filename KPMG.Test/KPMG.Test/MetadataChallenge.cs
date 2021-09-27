using Processor;
using System;
using System.Threading;

namespace KPMG.Test
{
    public interface IMetadataChallenge
    {
        void WriteMetadata(CancellationToken cancellationToken);        
    }

    public class MetadataChallenge : IMetadataChallenge
    {
        private readonly ICosmosDbMetadata _cosmosDbMetadata;
        public MetadataChallenge(ICosmosDbMetadata cosmosDbMetadata)
        {
            _cosmosDbMetadata = cosmosDbMetadata;
        }

        public void WriteMetadata(CancellationToken cancellationToken)
        {
            try
            {
                var metadataKeys = _cosmosDbMetadata.GetAccountSettingsAsync(cancellationToken).GetAwaiter().GetResult();
                Console.WriteLine($"Primary Metadata key : {metadataKeys.PrimaryMasterKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}-{ex.StackTrace}");
            }
        }
    }
}
