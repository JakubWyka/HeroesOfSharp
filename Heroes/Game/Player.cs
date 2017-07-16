using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Heroes.Game
{
    public class Player
    {
        String Name;
        Resources goods;
        Army PlayerArmy;
        List<Building> city; 

        internal Resources Goods { get => goods; set => goods = value; }
        public List<Building> City { get => city; set => city = value; }

        public Player(String n)
        {
            Name = n;
            PlayerArmy = new Army();
            goods = new Resources(100, 100, 100, 100);
            City.Add(new Wood(this));
            City.Add(new Claypit(this));
            City.Add(new Oremine(this));
            City.Add(new Townhall(this));
        }
    }
}
