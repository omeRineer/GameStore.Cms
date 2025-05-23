namespace GameStore.Cms.Models.Identity.User
{
    public class SetUserRolesModel
    {
        public Guid UserId { get; set; }
        public List<Guid>? Roles { get; set; }
    }
}
