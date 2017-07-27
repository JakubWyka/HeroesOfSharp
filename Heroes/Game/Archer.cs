using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Archer : Creature
    {
        public Archer() : base("Archer", "TODO", "Archer.png")
        {
            this.Attack = 2;
            this.Health = 1;
            this.Initiative = 3;
            this.Expense.Gold = 5;
            this.Expense.Wood = 5;
            this.Population = 0;
            this.IsFighting = "orange";
        }
    }
}
