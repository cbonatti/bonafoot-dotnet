using Bonafoot.Infra.Data.MongoDb.Configs;
using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bonafoot.Infra.Data.MongoDb
{
    public static class MongoModule
    {
        public static void RegisterMongoDb(this IServiceCollection services, ServerConfig config)
        {
            BonafootMongoDbContext.Config = config.MongoDB;
            var context = new BonafootMongoDbContext();
            services.AddSingleton<IBonafootMongoDbContext>(context);

            services.AddSingleton<IBonafootMongoDbContext, BonafootMongoDbContext>();
            services.AddSingleton<IGameRepository, GameRepository>();
        }
    }
}
