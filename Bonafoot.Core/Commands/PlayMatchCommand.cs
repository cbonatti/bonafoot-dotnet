using Bonafoot.Core.Commands.Base;
using System;
using System.Collections.Generic;

namespace Bonafoot.Core.Commands
{
    public class PlayMatchCommand : CommandBase
    {
        public IEnumerable<Guid> Players { get; set; }
    }
}
