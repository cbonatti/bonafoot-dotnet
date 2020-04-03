using Bonafoot.Domain.Enums;

namespace Bonafoot.Domain.Util
{
    public class PlayerStatsParam
    {
        public int MinStrength { get; private set; }
        public int MaxStrength { get; private set; }
        public int Salary { get; private set; }

        public static PlayerStatsParam GetParams(DivisionIndex division)
        {
            var param = new PlayerStatsParam();

            switch (division)
            {
                case DivisionIndex.First:
                    param.MinStrength = 39;
                    param.MaxStrength = 50;
                    param.Salary = 5000;
                    break;
                case DivisionIndex.Second:
                    param.MinStrength = 26;
                    param.MaxStrength = 39;
                    param.Salary = 4000;
                    break;
                case DivisionIndex.Third:
                    param.MinStrength = 12;
                    param.MaxStrength = 26;
                    param.Salary = 3000;
                    break;
                case DivisionIndex.Fourth:
                    param.MinStrength = 1;
                    param.MaxStrength = 13;
                    param.Salary = 2000;
                    break;
                default:
                    param.MinStrength = 1;
                    param.MaxStrength = 50;
                    param.Salary = 1000;
                    break;
            }

            return param;
        }
    }
}
