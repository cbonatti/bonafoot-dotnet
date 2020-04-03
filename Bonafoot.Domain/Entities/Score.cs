using Bonafoot.Domain.Base;

namespace Bonafoot.Domain.Entities
{
    public class Score : IdentityEntity
    {
        public Player Player { get; private set; }
        public int Minute { get; private set; }
    }
}
