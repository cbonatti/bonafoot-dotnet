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
            Squad = new List<Player>();
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
            Squad = players;
        }

        public string PrimaryColor { get; private set; }
        public string SecondaryColor { get; private set; }
        public int Moral { get; private set; }
        public int StadiumCapacity { get; private set; }
        public int TicketPrice { get; private set; }
        public IList<Player> Squad { get; private set; }
        public IList<Player> PlayingPlayers { get; private set; }

        public Team SetPlayerList(IList<Player> players)
        {
            PlayingPlayers = players;
            return this;
        }

        public Team SetPlayerList(IEnumerable<Guid> players)
        {
            PlayingPlayers = Squad.Where(x => players.Any(y => x.Id == y)).ToList();
            return this;
        }

        public Team AddPlayerToSquad(Player player)
        {
            Squad.Add(player);
            return this;
        }

        public Team RemovePlayerFromSquad(Player player)
        {
            Squad.Remove(player);
            return this;
        }

        /// <summary>
        /// Used in services to determine wheater playing team is user's team, so I need to set the players he selected
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public Team GetTeamReadyToPlay(Team team)
        {
            if (Id == team.Id)
                SetPlayerList(team.PlayingPlayers);
            else
                GenerateTeam();
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

        private Team GenerateTeam()
        {
            // TODO: Generate formation dynamically, for now 4-4-2 is enough
            var list = Squad
                            .Where(x => x.Position == PlayerPosition.Goalkeeper).OrderByDescending(x => x.Strength).Take(1)
                            .Union(Squad.Where(x => x.Position == PlayerPosition.Defender).OrderByDescending(x => x.Strength).Take(4))
                            .Union(Squad.Where(x => x.Position == PlayerPosition.Midfielder).OrderByDescending(x => x.Strength).Take(4))
                            .Union(Squad.Where(x => x.Position == PlayerPosition.Striker).OrderByDescending(x => x.Strength).Take(2))
                            .ToList();
            SetPlayerList(list);
            return this;
        }
    }
}
