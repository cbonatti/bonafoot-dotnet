using Bonafoot.Infra.Data.MongoDb.Configs;
using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Models;
using MongoDB.Driver;

namespace Bonafoot.Infra.Data.MongoDb
{
    public class BonafootMongoDbContext : IBonafootMongoDbContext
    {
        private readonly IMongoDatabase _db;

        public static MongoDBConfig Config { get; set; }

        public BonafootMongoDbContext()
        {
            var client = new MongoClient(Config.ConnectionString);
            _db = client.GetDatabase(Config.Database);
        }

        public IMongoCollection<GameMongoDb> Games => _db.GetCollection<GameMongoDb>("Games");
    }
}
