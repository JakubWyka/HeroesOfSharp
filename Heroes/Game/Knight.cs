using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Knight : Creature
    {
        public Knight() : base("Knight", "TODO", "Knight.jpg")
        {
            
            this.Attack = 3;
            this.Health = 2;
            this.Initiative = 2;
            this.Expense.Gold = 10;
            this.Population = 0;
        }
    }
}
