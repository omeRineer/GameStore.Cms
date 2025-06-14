namespace GameStore.Cms.Models.OData
{
    public class ODataBlog : ODataModel<Guid>
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int ReaderCount { get; set; }
        public bool Status { get; set; }
    }
}
