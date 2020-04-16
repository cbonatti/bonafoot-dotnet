using Bonafoot.Domain.Base;

namespace Bonafoot.Domain.Entities
{
    public class Score : IdentityEntity
    {
        public Score(int minute, string name, bool home)
        {
            Minute = minute;
            Name = name;
            Home = home;
        }

        public string Name { get; private set; }
        public int Minute { get; private set; }
        public bool Home { get; private set; }
    }
}
