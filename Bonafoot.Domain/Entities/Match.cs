using Bonafoot.Domain.Base;
using System.Collections.Generic;

namespace Bonafoot.Domain.Entities
{
    public class Match : IdentityEntity
    {
        public Team Home { get; set; }
        public Team Guest { get; set; }
        public IEnumerable<Score> HomeScores { get; set; }
        public IEnumerable<Score> GuestScores { get; set; }
    }
}
