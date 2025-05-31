namespace GameStore.Cms.Models.Rest.Menu
{
    public class SetMenuRolesModel
    {
        public Guid MenuId { get; set; }
        public List<Guid>? Roles { get; set; }
    }
}
