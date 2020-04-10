using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonafoot.Infra.Data.MongoDb.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IBonafootMongoDbContext _context;

        public GameRepository(IBonafootMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameMongoDb>> GetAll()
        {
            return await _context
                            .Games
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<GameMongoDb> Get(Guid id)
        {
            FilterDefinition<GameMongoDb> filter = Builders<GameMongoDb>.Filter.Eq(m => m.Game.Id, id);
            return _context
                    .Games
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<GameMongoDb> Get(string name)
        {
            FilterDefinition<GameMongoDb> filter = Builders<GameMongoDb>.Filter.Eq(m => m.Game.Name, name);
            return _context
                    .Games
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(GameMongoDb game)
        {
            await _context.Games.InsertOneAsync(game);
        }

        public async Task<bool> Update(GameMongoDb game)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Games
                        .ReplaceOneAsync(
                            filter: g => g.Game.Id == game.Game.Id,
                            replacement: game);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            FilterDefinition<GameMongoDb> filter = Builders<GameMongoDb>.Filter.Eq(m => m.Game.Id, id);
            DeleteResult deleteResult = await _context
                                                .Games
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<GameMongoDb> filter = Builders<GameMongoDb>.Filter.Eq(m => m.Game.Name, name);
            DeleteResult deleteResult = await _context
                                                .Games
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _context.Games.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
