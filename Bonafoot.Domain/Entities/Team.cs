using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using System;
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
            PlayingPlayers = new List<Player>();
        }

        public Team(string name, IList<Player> players)
        {
            SetName(name);
            SetPlayerList(players);
        }

        public Team(string name, IList<Player> players, int moral, string primaryColor, string secondaryColor, int stadiumCap, int ticketPrice)
        {
            SetName(name);
            Moral = moral;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            StadiumCapacity = stadiumCap;
            TicketPrice = ticketPrice;
            Players = players;
        }

        public string PrimaryColor { get; private set; }
        public string SecondaryColor { get; private set; }
        public int Moral { get; private set; }
        public int StadiumCapacity { get; private set; }
        public int TicketPrice { get; private set; }
        public IList<Player> Players { get; private set; }
        public IList<Player> PlayingPlayers { get; private set; }

        public Team SetPlayerList(IList<Player> players)
        {
            PlayingPlayers = players;
            return this;
        }

        public Team SetPlayerList(IEnumerable<Guid> players)
        {
            PlayingPlayers = Players.Where(x => players.Any(y => x.Id == y)).ToList();
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

        public double GK => PlayingPlayers.FirstOrDefault(x => x.Position == PlayerPosition.Goalkeeper).Strength * GkFactor;
        public double DF => PlayingPlayers.Where(x => x.Position == PlayerPosition.Defender).Average(x => x.Strength);
        public double MD => PlayingPlayers.Where(x => x.Position == PlayerPosition.Midfielder).Average(x => x.Strength);
        public double ST => PlayingPlayers.Where(x => x.Position == PlayerPosition.Striker).Average(x => x.Strength);

        public Team ApplyGkFactor(double factor)
        {
            GkFactor = factor;
            return this;
        }
    }
}
