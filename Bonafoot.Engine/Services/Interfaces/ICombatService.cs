using Bonafoot.Engine.Enums;

namespace Bonafoot.Engine.Services.Interfaces
{
    public interface ICombatService
    {
        CombatResult Fight(double home, double guest);
    }
}
