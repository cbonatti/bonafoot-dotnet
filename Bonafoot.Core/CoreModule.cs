using Bonafoot.Core.Services;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Core.Validators;
using Bonafoot.Core.Validators.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Core
{
    public static class CoreModule
    {
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlayingTeamValidator, PlayingTeamValidator>();
        }
    }
}
