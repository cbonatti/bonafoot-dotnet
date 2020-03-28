using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;

namespace Bonafoot.Engine
{
    public class MatchEngine : IMatchEngine
    {
        private readonly MatchResult Result;
        private readonly IRandomService randomService;
        private readonly Combat combat;

        public BallPosition BallPosition { get; private set; } = BallPosition.Center;

        public MatchEngine(Match match)
        {
            Result = new MatchResult(match);

            randomService = new RandomService();
            combat = new Combat(randomService);
        }

        public MatchEngine(Match match, IRandomService service) : this(match)
        {
            randomService = service;
            combat = new Combat(randomService);
        }

        public MatchResult PlayGame()
        {
            BallPosition = BallPosition.Center;

            for (int i = 0; i <= 90; i++)
            {
                Play();
            }

            return Result;
        }

        private void Play()
        {
            switch (BallPosition)
            {
                case BallPosition.HomeDef:
                    GuestStVsGk();
                    break;
                case BallPosition.HomeMid:
                    GuestMidVsDef();
                    break;
                case BallPosition.Center:
                    MidVsMid();
                    break;
                case BallPosition.GuestMid:
                    HomeMidVsDef();
                    break;
                case BallPosition.GuestDef:
                    HomeStVsGk();
                    break;
                default:
                    break;
            }
        }

        public void MidVsMid()
        {
            var result = combat.Fight(Result.Match.HomeTeam.MD, Result.Match.GuestTeam.MD);
            if (result == CombatResult.HomeWins)
                BallPosition = BallPosition.GuestMid;
            else if (result == CombatResult.GuestWins)
                BallPosition = BallPosition.HomeMid;
        }

        public void HomeMidVsDef()
        {
            var result = combat.Fight(Result.Match.HomeTeam.MD, Result.Match.GuestTeam.DF);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.HomeWins)
                BallPosition = BallPosition.GuestDef;
            else 
                BallPosition = BallPosition.Center;
        }

        public void GuestMidVsDef()
        {
            var result = combat.Fight(Result.Match.HomeTeam.DF, Result.Match.GuestTeam.MD);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.GuestWins)
                BallPosition = BallPosition.HomeDef;
            else
                BallPosition = BallPosition.Center;
        }

        public void HomeStVsGk()
        {
            var result = combat.Fight(Result.Match.HomeTeam.ST, Result.Match.GuestTeam.GK);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.HomeWins)
            {
                BallPosition = BallPosition.Center;
                Result.HomeTeamScored();
            }
            else
                BallPosition = BallPosition.GuestMid;
        }

        public void GuestStVsGk()
        {
            var result = combat.Fight(Result.Match.HomeTeam.GK, Result.Match.GuestTeam.ST);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.GuestWins)
            {
                BallPosition = BallPosition.Center;
                Result.GuestTeamScored();
            }
            else
                BallPosition = BallPosition.HomeMid;
        }
    }
}
