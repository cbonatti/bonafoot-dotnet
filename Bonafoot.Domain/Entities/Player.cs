using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;

namespace Bonafoot.Domain.Entities
{
    public class Player : EntityBase
    {
        public Player()
        {
        }

        public Player(string name, int strength, PlayerPosition position)
        {
            SetName(name);
            SetStrength(strength);
            SetPosition(position);
        }

        public Player(string name, int strength, PlayerPosition position, int salary) : this(name, strength, position)
        {
            SetSalary(salary);
        }

        public int Strength { get; private set; }
        public PlayerPosition Position { get; private set; }
        public int Salary { get; private set; }

        public Player SetStrength(int strength)
        {
            Strength = strength;
            return this;
        }

        public Player SetPosition(PlayerPosition position)
        {
            Position = position;
            return this;
        }

        public Player SetSalary(int salary)
        {
            Salary = salary;
            return this;
        }
    }
}
