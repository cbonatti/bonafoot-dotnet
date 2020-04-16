using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services;
using Bonafoot.Engine.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Engine
{
    public static class EngineModule
    {
        public static void RegisterEngine(this IServiceCollection services)
        {
            services.AddScoped<IRandomService, RandomService>();
            services.AddScoped<IMatchEngine, MatchEngine>();
            services.AddScoped<IPlayerScoredService, PlayerScoredService>();
            services.AddScoped<ICombatService, CombatService>();
        }
    }
}
