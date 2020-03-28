using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Domain.Entities
{
    public class Team : EntityBase
    {
        private double GkFactor = 1; // Used to let GK a little stronger. Its definition will be at game engine so its starts with value 1

        public Team()
        {
            Players = new List<Player>();
        }

        public Team(string name, IList<Player> players)
        {
            SetName(name);
            SetPlayerList(players);
        }

        public IList<Player> Players { get; private set; }

        public Team SetPlayerList(IList<Player> players)
        {
            Players = players;
            return this;
        }

        public Team AddPlayer(Player player)
        {
            Players.Add(player);
            return this;
        }

        public Team RemovePlayer(Player player)
        {
            Players.Remove(player);
            return this;
        }

        public double GK => Players.FirstOrDefault(x => x.Position == PlayerPosition.Goalkeeper).Strength * GkFactor;
        public double DF => Players.Where(x => x.Position == PlayerPosition.Defender).Average(x => x.Strength);
        public double MD => Players.Where(x => x.Position == PlayerPosition.Midfielder).Average(x => x.Strength);
        public double ST => Players.Where(x => x.Position == PlayerPosition.Striker).Average(x => x.Strength);

        public Team ApplyGkFactor(double factor)
        {
            GkFactor = factor;
            return this;
        }
    }
}
