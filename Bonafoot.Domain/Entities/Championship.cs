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
        public IList<Match> Matches { get; private set; }
        public ChampionshipStatus Status { get; private set; }
        public int ActualRound { get; private set; }
        public IList<ChampionshipRound> Rounds { get; private set; }

        public Championship New()
        {
            Year = DateTime.Now.Year;
            Status = ChampionshipStatus.Active;
            ActualRound = 1;
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

        public Championship FinishRound()
        {
            ActualRound++;
            return this;
        }

        public IList<ChampionshipRound> GetActualRound() => Rounds.Where(x => x.Round == ActualRound).ToList();

        public Championship AddMatch(Match match)
        {
            Matches.Add(match);
            return this;
        }

        public Division GetDivision(DivisionIndex index) => Divisions.FirstOrDefault(x => x.Index == index);

        // TODO: Should I extract this methods (AddRound, GenerateRounds, GenerateReturnRounds) to another class? Or generating rounds is championship obligation?
        private bool AddRound(Team home, Team guest, int round, DivisionIndex division)
        {
            if (Rounds.Where(x => x.Round == round && x.Division == division).Any(x => (x.HomeTeam.Id == home.Id || x.GuestTeam.Id == guest.Id) || (x.GuestTeam.Id == home.Id || x.HomeTeam.Id == guest.Id)))
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
                    for (int teamAgainst = 0; teamAgainst < 8; teamAgainst++)
                    {
                        int round = 1;
                        if (team != teamAgainst)
                        {
                            while (!AddRound(division.Teams.ElementAt(team), division.Teams.ElementAt(teamAgainst), round, division.Index) && round < 7)
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
