namespace Bonafoot.Engine.Engine
{
    public class PlayerScore
    {
        public PlayerScore(int minute, string name, bool home)
        {
            Minute = minute;
            Name = name;
            Home = home;
        }

        public int Minute { get; private set; }
        public string Name { get; private set; }
        public bool Home { get; private set; }
    }
}
