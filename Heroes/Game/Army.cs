using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Army
    {
        Dragon dragons;
        Gryphon gryphons;
        Archer archers;
        Knight knights;

        public Dragon Dragons { get => dragons; set => dragons = value; }
        public Gryphon Gryphons { get => gryphons; set => gryphons = value; }
        public Archer Archers { get => archers; set => archers = value; }
        public Knight Knights { get => knights; set => knights = value; }



        public Army()
        {
            dragons = new Dragon();
            gryphons = new Gryphon();
            archers = new Archer();
            knights = new Knight();
        }
    }
}
