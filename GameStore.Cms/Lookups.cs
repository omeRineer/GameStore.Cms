namespace GameStore.Cms
{
    // TODO Lookup Servisi yazıldığında burası kalkacak
    public static class Lookups
    {
        public static Dictionary<string, string> NotificationTypes = new Dictionary<string, string>
        {
            { "error", "danger" },
            { "info", "info" },
            { "warning", "warning" },
            { "success", "success" }
        };

        public static Dictionary<string, string> NotificationTags = new Dictionary<string, string>
        {
            { "system", "system" },
            { "simple", "simple" }
        };

        public static Dictionary<string, string> QueueMessageStatuses = new Dictionary<string, string>
        {
            { "Error", "danger" },
            { "Success", "success" },
            { "Processing", "warning" },
        };
    }
}
