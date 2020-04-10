using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameContract> New(NewGameCommand command);
        Task<GameContract> Load(LoadGameCommand command);
        Task<IEnumerable<GameContract>> GetAll();
        Task<bool> Delete(DeleteGameCommand command);
    }
}
