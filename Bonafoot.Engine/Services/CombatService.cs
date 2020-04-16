using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services.Interfaces;

namespace Bonafoot.Engine.Services
{
    public class CombatService : ICombatService
    {
        private readonly IRandomService _randomService;

        public CombatService(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public CombatResult Fight(double home, double guest)
        {
            home += _randomService.Generate(MatchConfig.COMBAT_RANDOM_FACTOR_MIN, MatchConfig.COMBAT_RANDOM_FACTOR_MAX);
            guest += _randomService.Generate(MatchConfig.COMBAT_RANDOM_FACTOR_MIN, MatchConfig.COMBAT_RANDOM_FACTOR_MAX);

            if (home > guest)
                return CombatResult.HomeWins;
            else if (guest > home)
                return CombatResult.GuestWins;

            return CombatResult.Draw;
        }
    }
}
