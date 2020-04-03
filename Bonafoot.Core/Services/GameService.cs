using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bonafoot.Core.Services
{
    public class GameService : IGameService
    {
        public GameContract New(string name)
        {
            var game = new Game().New();

            var contract = new GameContract();
            return contract;
        }

        public GameContract Load(string name)
        {
            var contract = new GameContract();
            return contract;
        }
    }
}
