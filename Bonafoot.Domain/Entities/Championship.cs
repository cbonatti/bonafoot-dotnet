﻿using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Bonafoot.Domain.Entities
{
    public class Championship : IdentityEntity
    {
        public Championship()
        {
            Matches = new List<Match>();
        }

        public int Year { get; private set; }
        public IEnumerable<Division> Divisions { get; private set; }
        public IEnumerable<Match> Matches { get; private set; }

        public Championship New()
        {
            Year = DateTime.Now.Year;
            Divisions = new List<Division>()
            {
                new Division(DivisionIndex.First),
                new Division(DivisionIndex.Second),
                new Division(DivisionIndex.Third),
                new Division(DivisionIndex.Fourth)
            };
            return this;
        }
    }
}
