using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Contracts
{
    public class ChampionshipRoundContract
    {
        public int Round { get; set; }
        public TeamContract HomeTeam { get; set; }
        public TeamContract GuestTeam { get; set; }

        public static ChampionshipRoundContract ToContract(ChampionshipRound round)
        {
            if (round == null)
                return null;
            return new ChampionshipRoundContract()
            {
                Round = round.Round,
                HomeTeam = TeamContract.ToSimpleContract(round.HomeTeam),
                GuestTeam = TeamContract.ToSimpleContract(round.GuestTeam)
            };
        }
    }
}
