namespace KPMG.Processor
{
    public class DatabaseAccountListKeyResults
    {
        public string PrimaryMasterKey { get; set; }
        public string PrimaryReadonlyMasterKey { get; set; }
        public string SecondaryMasterKey { get; set; }
        public string SecondaryReadonlyMasterKey { get; set; }
    }
}