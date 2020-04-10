using Bonafoot.Infra.Data.MongoDb.Configs;
using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Models;
using MongoDB.Driver;

namespace Bonafoot.Infra.Data.MongoDb
{
    public class BonafootMongoDbContext : IBonafootMongoDbContext
    {
        private readonly IMongoDatabase _db;

        public BonafootMongoDbContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<GameMongoDb> Games => _db.GetCollection<GameMongoDb>("Games");
    }
}
