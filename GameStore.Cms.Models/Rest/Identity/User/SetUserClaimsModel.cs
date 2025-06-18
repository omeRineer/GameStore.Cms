namespace GameStore.Cms.Models.Rest.Identity.User
{
    public class SetUserClaimsModel
    {
        public Guid UserId { get; set; }
        public Dictionary<string, string>? Claims { get; set; }
    }
}
