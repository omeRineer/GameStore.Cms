namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataUserPermission : ODataModel<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public ODataUser User { get; set; }
        public ODataPermission Permission { get; set; }
    }

}
