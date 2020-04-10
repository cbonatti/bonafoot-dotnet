using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;

namespace Bonafoot.Engine
{
    public class Combat
    {
        private readonly IRandomService randomService;

        public Combat(IRandomService randomService)
        {
            this.randomService = randomService;
        }

        public CombatResult Fight(double home, double guest)
        {
            home += randomService.Generate(MatchConfig.COMBAT_RANDOM_FACTOR_MIN, MatchConfig.COMBAT_RANDOM_FACTOR_MAX);
            guest += randomService.Generate(MatchConfig.COMBAT_RANDOM_FACTOR_MIN, MatchConfig.COMBAT_RANDOM_FACTOR_MAX);

            if (home > guest)
                return CombatResult.HomeWins;
            else if (guest > home)
                return CombatResult.GuestWins;

            return CombatResult.Draw;
        }
    }
}
