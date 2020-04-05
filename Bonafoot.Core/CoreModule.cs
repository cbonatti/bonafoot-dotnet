using Bonafoot.Core.Services;
using Bonafoot.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Core
{
    public static class CoreModule
    {
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
        }
    }
}
