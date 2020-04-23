using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services.Interfaces;

namespace Bonafoot.Engine
{
    public class MatchEngine : IMatchEngine
    {
        private MatchResult Result;
        private int _minute;
        private readonly IPlayerScoredService _playerScoredService;
        private readonly ICombatService _combatService;
        private readonly IRandomService _randomService;

        public BallPosition BallPosition { get; private set; } = BallPosition.Center;

        public MatchEngine(IPlayerScoredService playerScoredService, ICombatService combatService, IRandomService randomService)
        {
            _playerScoredService = playerScoredService;
            _combatService = combatService;
            _randomService = randomService;
        }

        public MatchEngine SetMatch(Match match)
        {
            Result = new MatchResult(match);
            return this;
        }

        public MatchResult PlayGame(Match match)
        {
            SetMatch(match);
            BallPosition = BallPosition.Center;

            for (_minute = 0; _minute <= 90; _minute++)
            {
                if (_minute == 45)
                    BallPosition = BallPosition.Center;
                for (int play = 0; play < 2; play++) // 2 plays per minute
                    Play();
            }

            return Result;
        }

        private void Play()
        {
            if (!Advance())
                return;

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
            var result = _combatService.Fight(Result.Match.HomeTeam.MD, Result.Match.GuestTeam.MD);
            if (result == CombatResult.HomeWins)
                BallPosition = BallPosition.GuestMid;
            else if (result == CombatResult.GuestWins)
                BallPosition = BallPosition.HomeMid;
        }

        public void HomeMidVsDef()
        {
            var result = _combatService.Fight(Result.Match.HomeTeam.MD, Result.Match.GuestTeam.DF);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.HomeWins)
                BallPosition = BallPosition.GuestDef;
            else 
                BallPosition = BallPosition.Center;
        }

        public void GuestMidVsDef()
        {
            var result = _combatService.Fight(Result.Match.HomeTeam.DF, Result.Match.GuestTeam.MD);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.GuestWins)
                BallPosition = BallPosition.HomeDef;
            else
                BallPosition = BallPosition.Center;
        }

        public void HomeStVsGk()
        {
            var result = _combatService.Fight(Result.Match.HomeTeam.ST, Result.Match.GuestTeam.GK);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.HomeWins)
            {
                BallPosition = BallPosition.Center;
                Result.HomeTeamScored(_minute, _playerScoredService.WhoScored(Result.Match.HomeTeam));
            }
            else
                BallPosition = BallPosition.GuestMid;
        }

        public void GuestStVsGk()
        {
            var result = _combatService.Fight(Result.Match.HomeTeam.GK, Result.Match.GuestTeam.ST);
            if (result == CombatResult.Draw) return;

            if (result == CombatResult.GuestWins)
            {
                BallPosition = BallPosition.Center;
                Result.GuestTeamScored(_minute, _playerScoredService.WhoScored(Result.Match.GuestTeam));
            }
            else
                BallPosition = BallPosition.HomeMid;
        }

        private bool Advance()
        {
            var result = _randomService.Dice() + _randomService.Dice();
            return result > MatchConfig.PARAMETER_ADVANCE;
        }
    }
}
