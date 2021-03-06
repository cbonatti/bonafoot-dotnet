﻿using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class TeamContract : ContractBaseWithId
    {
        public int Money { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public int Moral { get; set; }
        public int StadiumCapacity { get; set; }
        public int TicketPrice { get; set; }
        public DivisionIndex Division { get; set; }
        public IList<PlayerContract> Squad { get; set; }

        public static TeamContract ToContract(Team team)
        {
            if (team == null)
                return null;
            return new TeamContract()
            {
                Id = team.Id,
                Name = team.Name,
                Money = team.Money,
                Moral = team.Moral,
                PrimaryColor = team.PrimaryColor,
                SecondaryColor = team.SecondaryColor,
                StadiumCapacity = team.StadiumCapacity,
                TicketPrice = team.TicketPrice,
                Squad = team.Squad.Select(PlayerContract.ToContract).ToList()
            };
        }

        public static TeamContract ToPlayerContract(Team team, DivisionIndex division)
        {
            if (team == null)
                return null;
            return new TeamContract()
            {
                Id = team.Id,
                Name = team.Name,
                Money = team.Money,
                Moral = team.Moral,
                Division = division,
                PrimaryColor = team.PrimaryColor,
                SecondaryColor = team.SecondaryColor,
                StadiumCapacity = team.StadiumCapacity,
                TicketPrice = team.TicketPrice,
                Squad = team.Squad.Select(PlayerContract.ToContract).ToList()
            };
        }

        public static TeamContract ToSimpleContract(Team team)
        {
            if (team == null)
                return null;
            return new TeamContract()
            {
                Id = team.Id,
                Name = team.Name,
                Money = team.Money,
                PrimaryColor = team.PrimaryColor,
                SecondaryColor = team.SecondaryColor
            };
        }
    }
}
