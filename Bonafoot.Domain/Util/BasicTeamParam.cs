using Bonafoot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Bonafoot.Domain.Util
{
    public class BasicTeamParam
    {
        public int Money { get; private set; }
        public string PrimaryColor { get; private set; }
        public string SecondaryColor { get; private set; }
        public int StadiumCap { get; private set; }
        public int TicketPrice { get; private set; }

        public static BasicTeamParam GetParam(DivisionIndex division)
        {
            var param = new BasicTeamParam
            {
                PrimaryColor = GetColor(),
                SecondaryColor = GetColor()
            };

            // just to be sure they are differents
            while (param.SecondaryColor.Equals(param.PrimaryColor))
                param.SecondaryColor = GetColor();

            switch (division)
            {
                case DivisionIndex.First:
                    param.TicketPrice = 50;
                    param.StadiumCap = 50000;
                    param.Money = 5000000;
                    break;
                case DivisionIndex.Second:
                    param.TicketPrice = 40;
                    param.StadiumCap = 40000;
                    param.Money = 4700000;
                    break;
                case DivisionIndex.Third:
                    param.TicketPrice = 30;
                    param.StadiumCap = 30000;
                    param.Money = 3300000;
                    break;
                case DivisionIndex.Fourth:
                    param.TicketPrice = 20;
                    param.StadiumCap = 20000;
                    param.Money = 1500000;
                    break;
                default:
                    break;
            }

            return param;
        }

        private static string GetColor()
        {
            var colors = GetColors();
            var index = new Random().Next(1, colors.Count);
            return colors[index];
        }

        private static IList<string> GetColors() => new List<string>()
        {
            "Black",
            "Gray",
            "LightGrey",
            "SlateBlue",
            "MidnightBlue",
            "DarkBlue",
            "Blue",
            "RoyalBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSteelBlue",
            "Aqua",
            "Turquoise",
            "DarkCyan",
            "CadetBlue",
            "SpringGreen",
            "PaleGreen",
            "MediumSeaGreen",
            "DarkGreen",
            "Lime",
            "GreenYellow",
            "OliveDrab",
            "Olive",
            "DarkKhaki",
            "Goldenrod",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "NavajoWhite",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkMagenta",
            "Magenta",
            "DeepPink",
            "Crimson",
            "DarkRed",
            "FireBrick",
            "Salmon",
            "Coral",
            "Red",
            "OrangeRed",
            "Orange",
            "Yellow",
            "White"
        };
    }
}
