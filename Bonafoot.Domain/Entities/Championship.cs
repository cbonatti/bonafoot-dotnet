using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Domain.Entities
{
    public class Championship : IdentityEntity
    {
        public Championship()
        {
            Matches = new List<Match>();
            Rounds = new List<ChampionshipRound>();
        }

        public int Year { get; private set; }
        public IList<Division> Divisions { get; private set; }
        public IEnumerable<Match> Matches { get; private set; }
        public ChampionshipStatus Status { get; private set; }
        public int ActualRound { get; private set; }
        public IList<ChampionshipRound> Rounds { get; private set; }

        public Championship New()
        {
            Year = DateTime.Now.Year;
            Status = ChampionshipStatus.Active;
            ActualRound = 0;
            Divisions = new List<Division>()
            {
                new Division(DivisionIndex.First),
                new Division(DivisionIndex.Second),
                new Division(DivisionIndex.Third),
                new Division(DivisionIndex.Fourth)
            }.ToList();

            GenerateRounds();
            return this;
        }

        public Championship Finish()
        {
            // TODO: Needs to create a new championship
            Status = ChampionshipStatus.Finished;
            return this;
        }


        // TODO: Should I extract this methods (AddRound, GenerateRounds, GenerateReturnRounds) to another class? Or generating rounds is championship obligation?
        private bool AddRound(Team home, Team guest, int round, DivisionIndex division)
        {
            if (Rounds.Any(x => (x.HomeTeam.Id == home.Id && x.GuestTeam.Id == guest.Id) || (x.GuestTeam.Id == home.Id && x.HomeTeam.Id == guest.Id)))
                return false;
            Rounds.Add(new ChampionshipRound(round, home, guest, division));
            return true;
        }

        private void GenerateRounds()
        {
            foreach (var division in Divisions)
            {
                for (int team = 0; team < 8; team++)
                {
                    int round = 1;
                    for (int teamAgainst = 0; teamAgainst < 8; teamAgainst++)
                    {
                        if (team != teamAgainst)
                        {
                            if (AddRound(division.Teams.ElementAt(team), division.Teams.ElementAt(teamAgainst), round, division.Index))
                                round++;
                        }
                    }
                }
            }

            GenerateReturnRounds();
        }

        private void GenerateReturnRounds()
        {
            var count = Rounds.Count;
            for (int i = 0; i < count; i++)
            {
                var round = Rounds[i]; // round.Round + 7, cause round 1 its return round should be 8, 2 - 9, 3 - 10.... 7 - 14
                Rounds.Add(new ChampionshipRound(round.Round + 7, round.GuestTeam, round.HomeTeam, round.Division));
            }
        }
    }
}
