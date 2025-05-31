namespace GameStore.Cms.Models.Rest.Menu
{
    public class UpdateMenuModel
    {
        public Guid Id { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string? Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }
    }
}
