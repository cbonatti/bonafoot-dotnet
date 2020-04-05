using System;
using System.Collections.Generic;

namespace Bonafoot.Core.Commands
{
    public class PlayMatchCommand
    {
        public IEnumerable<Guid> Players { get; set; }
    }
}
