using Microsoft.Extensions.DependencyInjection;

namespace Service.DependencyInjection
{
    public static class SessionDependecyInjection
    {
        public static IServiceCollection AddProjectSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(x =>
            {
                x.Cookie.HttpOnly = true;
                x.IdleTimeout = TimeSpan.FromMinutes(1);
                x.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}
