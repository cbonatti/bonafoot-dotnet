using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;

namespace Bonafoot.Core.Contracts
{
    public class PlayerContract : ContractBaseWithId
    {
        public int Strength { get; set; }
        public PlayerPosition Position { get; set; }
        public int Salary { get; set; }

        public static PlayerContract ToContract(Player player)
        {
            if (player == null)
                return null;
            return new PlayerContract()
            {
                Id = player.Id,
                Name = player.Name,
                Position = player.Position,
                Salary = player.Salary,
                Strength = player.Strength
            };
        }
    }
}
