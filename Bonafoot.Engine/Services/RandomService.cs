using Bonafoot.Engine.Interfaces;
using System;

namespace Bonafoot.Engine.Services
{
    public class RandomService : IRandomService
    {
        public int Generate(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public int Dice()
        {
            var random = new Random();
            return random.Next(1, 6);
        }

        public int ZeroToMax(int max)
        {
            var random = new Random();
            return random.Next(0, max);
        }
    }
}
