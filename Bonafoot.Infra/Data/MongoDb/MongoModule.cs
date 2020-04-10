using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Infra.Data.MongoDb
{
    public static class MongoModule
    {
        public static void RegisterMongoDb(this IServiceCollection services)
        {
            services.AddSingleton<IGameRepository, GameRepository>();
        }
    }
}
