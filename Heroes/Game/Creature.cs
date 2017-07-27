using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    abstract public class Creature : GameObject
    {
        int attack;
        int initiative;
        int health;
        int population;
        Resources expense;
        string isFighting;

        public int Attack { get => attack; set => attack = value; }
        public int Initiative { get => initiative; set => initiative = value; }
        public int Health { get => health; set => health = value; }
        public int Population { get => population; set => population = value; }
        public Resources Expense { get => expense;  set => expense = value; } //dodac protected w set
        public string IsFighting { get => isFighting; set => isFighting = value; }


        public Creature(String Name, String Description, String FileName) : base(Name, Description, FileName)
        {
            expense = new Resources();
        }

        public void AddReinforcements(int add)
        {
            if (add > 0)
            {
                Population = Population + add;
            }
        }
        public void Kill(double howMuch)
        {
            
          
            Population = Population -(int)howMuch-1;
            if (Population < 0)
            {
                Population = 0;
            }
        }
    }
}
