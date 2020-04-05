using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IGameService
    {
        GameContract New(NewGameCommand command);
        GameContract Load(LoadGameCommand command);
    }
}
