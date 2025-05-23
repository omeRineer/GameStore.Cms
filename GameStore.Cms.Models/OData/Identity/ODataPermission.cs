namespace GameStore.Cms.Models.OData.Identity
{
    public class ODataPermission: ODataModel<Guid>
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<ODataUserPermission>? UserPermissions { get; set; }
    }

}
