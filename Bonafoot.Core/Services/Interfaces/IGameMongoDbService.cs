using Bonafoot.Core.Commands;
using Bonafoot.Infra.Data.MongoDb.Models;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IGameMongoDbService
    {
        Task<GameMongoDb> Get(LoadGameCommand command);
    }
}
