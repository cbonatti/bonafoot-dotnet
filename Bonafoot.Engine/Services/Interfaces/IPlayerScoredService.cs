using Bonafoot.Domain.Entities;

namespace Bonafoot.Engine.Services.Interfaces
{
    public interface IPlayerScoredService
    {
        string WhoScored(Team team);
    }
}
