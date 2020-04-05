using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;

namespace Bonafoot.Core.Services
{
    public class MatchService : IMatchService
    {
        public ChampionshipContract Play(PlayMatchCommand command)
        {


            return new ChampionshipContract();
        }
    }
}
