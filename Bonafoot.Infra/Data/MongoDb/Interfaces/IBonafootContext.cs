using Bonafoot.Infra.Data.MongoDb.Models;
using MongoDB.Driver;

namespace Bonafoot.Infra.Data.MongoDb.Interfaces
{
    public interface IBonafootMongoDbContext
    {
        IMongoCollection<GameMongoDb> Games { get; }
    }
}
