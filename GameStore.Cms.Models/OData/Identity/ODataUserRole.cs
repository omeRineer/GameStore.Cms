namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataUserRole : ODataModel<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public ODataUser User { get; set; }
        public ODataRole Role { get; set; }
    }

}
