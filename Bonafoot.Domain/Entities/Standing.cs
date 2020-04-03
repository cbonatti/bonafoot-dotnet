using Bonafoot.Domain.Base;

namespace Bonafoot.Domain.Entities
{
    public class Standing : EntityBase
    {
        public Team Team { get; private set; }
        public int Victory { get; private set; }
        public int Draw { get; private set; }
        public int Loss { get; private set; }
        public int ScoresPro { get; private set; }
        public int ScoresCon { get; private set; }
    }
}