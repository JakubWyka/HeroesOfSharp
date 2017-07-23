using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Dragon : Creature
    {
        public Dragon() : base("Dragon", "TODO", "Dragon.png")
        {
           
            this.Attack = 7;
            this.Health = 10;
            this.Initiative = 4;
            this.Expense.Ore = 5;
            this.Expense.Gold = 20;
            this.Population = 0;
        }
    }
}