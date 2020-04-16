namespace Bonafoot.Engine.Interfaces
{
    public interface IRandomService
    {
        int Generate(int min, int max);
        /// <summary>
        /// Return a number between 1 and 6, like a dice
        /// </summary>
        /// <returns></returns>
        int Dice();
        int ZeroToMax(int max);
    }
}
