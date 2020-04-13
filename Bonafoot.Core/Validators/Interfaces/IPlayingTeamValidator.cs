using Bonafoot.Core.Commands;
using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Validators.Interfaces
{
    public interface IPlayingTeamValidator
    {
        bool Validate(PlayMatchCommand command, Team team);
    }
}
