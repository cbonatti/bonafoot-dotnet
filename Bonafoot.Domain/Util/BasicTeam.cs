using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Bonafoot.Domain.Util
{
    public class BasicTeam
    {
        public static Team Generate(DivisionIndex division, int index)
        {
            var playerParams = PlayerStatsParam.GetParams(division);
            var teamParams = BasicTeamParam.GetParam(division);
            var random = new Random();

            var players = new List<Player>()
            {
                new Player("GK 1", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Goalkeeper, playerParams.Salary),
                new Player("GK 2", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Goalkeeper, playerParams.Salary),
                new Player("DF 1", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Defender, playerParams.Salary),
                new Player("DF 2", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Defender, playerParams.Salary),
                new Player("DF 3", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Defender, playerParams.Salary),
                new Player("DF 4", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Defender, playerParams.Salary),
                new Player("DF 5", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Defender, playerParams.Salary),
                new Player("MF 1", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Midfielder, playerParams.Salary),
                new Player("MF 2", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Midfielder, playerParams.Salary),
                new Player("MF 3", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Midfielder, playerParams.Salary),
                new Player("MF 4", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Midfielder, playerParams.Salary),
                new Player("ST 1", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Striker, playerParams.Salary),
                new Player("ST 2", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Striker, playerParams.Salary),
                new Player("ST 3", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Striker, playerParams.Salary),
                new Player("ST 4", random.Next(playerParams.MinStrength, playerParams.MaxStrength), PlayerPosition.Striker, playerParams.Salary),
            };

            return new Team($"Team {index}", players, teamParams.Money, 50, teamParams.PrimaryColor, teamParams.SecondaryColor, teamParams.StadiumCap, teamParams.TicketPrice);
        }
    }
}
