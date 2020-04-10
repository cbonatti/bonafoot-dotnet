using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Engine
{
    public static class EngineModule
    {
        public static void RegisterEngine(this IServiceCollection services)
        {
            services.AddScoped<IRandomService, RandomService>();
            services.AddScoped<IMatchEngine, MatchEngine>();
        }
    }
}
