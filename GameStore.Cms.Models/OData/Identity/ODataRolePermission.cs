namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataRolePermission : ODataModel<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public ODataRole Role { get; set; }
        public ODataPermission Permission { get; set; }
    }

}
