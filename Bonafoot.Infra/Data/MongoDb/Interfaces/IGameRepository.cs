using Bonafoot.Infra.Data.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonafoot.Infra.Data.MongoDb.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameMongoDb>> GetAll();
        Task<GameMongoDb> Get(Guid id);
        Task<GameMongoDb> Get(string name);
        Task Create(GameMongoDb todo);
        Task<bool> Update(GameMongoDb todo);
        Task<bool> Delete(Guid id);
        Task<long> GetNextId();
    }
}
