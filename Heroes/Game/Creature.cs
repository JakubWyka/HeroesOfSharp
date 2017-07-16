using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    abstract public class Creature
    {
        int attack;
        int initiative;
        int health;
        Resources expense;

        public int Attack { get => attack; set => attack = value; }
        public int Initiative { get => initiative; set => initiative = value; }
        public int Health { get => health; set => health = value; }
        public Resources Expense { get => expense;  set => expense = value; } //dodac protected w set
    }
}
