﻿using Bonafoot.Engine.Interfaces;
using System;

namespace Bonafoot.Engine.Services
{
    public class RandomService : IRandomService
    {
        public double Generate(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}