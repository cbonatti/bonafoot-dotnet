namespace Bonafoot.Engine.Interfaces
{
    public interface IMatchEngine
    {
        MatchResult PlayGame(Match match);
        MatchEngine SetMatch(Match match);
    }
}
