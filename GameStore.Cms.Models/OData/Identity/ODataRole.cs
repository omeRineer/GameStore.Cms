namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataRole : ODataModel<Guid>
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<ODataUserRole>? UserRoles { get; set; }
        public IEnumerable<ODataRolePermission>? RolePermissions { get; set; }
    }

}
