using Bonafoot.Core.Contracts;

namespace Bonafoot.Core.Services.Interfaces
{
    public interface IGameService
    {
        GameContract New(string name);
        GameContract Load(string name);
    }
}
