namespace GameStore.Cms.Models.OData
{
    public class ODataGame : ODataModel<Guid>
    {
        public Guid CategoryId { get; set; }
        public int? DeveloperId { get; set; }
        public int? DistributorId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }


        public ODataCategory Category { get; set; }
    }
}
