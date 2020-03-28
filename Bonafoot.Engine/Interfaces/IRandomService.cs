using System;

namespace Bonafoot.Engine.Interfaces
{
    public interface IRandomService
    {
        double Generate(int min, int max);
    }

    public class RandomService : IRandomService
    {
        public double Generate(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
