using Bonafoot.Domain.Base;
using System.Collections.Generic;

namespace Bonafoot.Domain.Entities
{
    public class Game : EntityBase
    {
        public Game()
        {
        }

        public Game(string name, IList<Team> teams)
        {
            SetName(name);
            Teams = teams;
        }

        public IList<Team> Teams { get; private set; }
    }
}
