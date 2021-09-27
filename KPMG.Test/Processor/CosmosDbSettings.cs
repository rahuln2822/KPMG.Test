namespace Processor
{
    public class CosmosDbSettings
    {
        public string DatabaseResourceId { get; set; }
        public string PostFixUrl { get; set; } = "/listKeys?api-version=2019-12-12";
    }
}