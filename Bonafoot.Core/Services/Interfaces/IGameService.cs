using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Infra.Data.MongoDb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameContract> New(NewGameCommand command);
        Task<GameContract> Update(GameMongoDb game);
        Task<GameContract> Load(LoadGameCommand command);
        Task<IEnumerable<GameContract>> GetAll();
        Task<bool> Delete(DeleteGameCommand command);
    }
}
