using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IMatchService
    {
        ChampionshipContract Play(PlayMatchCommand command);
    }
}
