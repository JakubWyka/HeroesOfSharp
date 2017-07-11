using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeroesOfSharp
{
    class Player
    {
        String Name;
        Resources goods;
        internal Resources Goods { get => goods; set => goods = value; }

        public Player(String n)
        {
            Name = n;
            goods = new Resources(100, 100, 100, 100);
        }
    }
}
