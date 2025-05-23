namespace GameStore.Cms.Providers
{
    public static class StaticServiceProvider
    {
        private static IServiceScopeFactory ServiceScopeFactory { get; set; }
        public static void CreateInstance(IServiceScopeFactory serviceScopeFactory)
        {
            if (ServiceScopeFactory != null)
                throw new Exception("Provider is not null!");

            ServiceScopeFactory = serviceScopeFactory;
        }

        public static TService GetService<TService>()
        {
            var serviceScope = ServiceScopeFactory.CreateScope();
            return serviceScope.ServiceProvider.GetService<TService>();
        }
    }
}
