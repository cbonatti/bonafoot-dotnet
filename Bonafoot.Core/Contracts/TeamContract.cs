using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class TeamContract : ContractBaseWithId
    {
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public int Moral { get; set; }
        public int StadiumCapacity { get; set; }
        public int TicketPrice { get; set; }
        public IList<PlayerContract> Players { get; set; }

        public static TeamContract ToContract(Team team)
        {
            if (team == null)
                return null;
            return new TeamContract()
            {
                Id = team.Id,
                Name = team.Name,
                Moral = team.Moral,
                PrimaryColor = team.PrimaryColor,
                SecondaryColor = team.SecondaryColor,
                StadiumCapacity = team.StadiumCapacity,
                TicketPrice = team.TicketPrice,
                Players = team.Players.Select(PlayerContract.ToContract).ToList()
            };
        }
    }
}
