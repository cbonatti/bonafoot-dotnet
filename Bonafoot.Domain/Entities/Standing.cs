using Bonafoot.Domain.Base;

namespace Bonafoot.Domain.Entities
{
    public class Standing : EntityBase
    {
        public Standing()
        {
        }

        public Standing(Team team)
        {
            Team = team;
            SetName(team.Name);
        }

        public Team Team { get; private set; }
        public int Victory { get; private set; }
        public int Draw { get; private set; }
        public int Loss { get; private set; }
        public int ScoresPro { get; private set; }
        public int ScoresCon { get; private set; }
        public int Points { get; private set; }

        public Standing SetVictory(int scorePro, int scoreCon)
        {
            Victory++;
            SetScore(scorePro, scoreCon);
            Points += 3;
            return this;
        }

        public Standing SetDefeat(int scorePro, int scoreCon)
        {
            Loss++;
            SetScore(scorePro, scoreCon);
            return this;
        }

        public Standing SetDraw(int score)
        {
            Draw++;
            SetScore(score, score);
            Points += 1;
            return this;
        }

        private void SetScore(int scorePro, int scoreCon)
        {
            ScoresPro += scorePro;
            ScoresCon += scoreCon;
        }
    }
}