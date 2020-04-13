using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IMatchService
    {
        Task<ChampionshipContract> Play(PlayMatchCommand command);
    }
}
