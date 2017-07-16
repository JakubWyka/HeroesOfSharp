using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Gryphon : Creature
    {
        public Gryphon()
        {
            this.Attack = 4;
            this.Health = 3;
            this.Initiative = 3;
            this.Expense.Gold = 15;
        }
    }
}
