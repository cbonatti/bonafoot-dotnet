using Bonafoot.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bonafoot.Infra.Data.MongoDb.Models
{
    public class GameMongoDb
    {
        public GameMongoDb()
        {
        }

        public GameMongoDb(Game game)
        {
            Game = game;
        }

        [BsonId]
        public ObjectId InternalId { get; set; }
        public virtual Game Game { get; set; }
    }
}
