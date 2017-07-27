using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Army
    {
        Creature dragons;
        Creature gryphons;
        Creature archers;
        Creature knights;
        Creature[] container;

        public Creature Dragons { get => dragons; set => dragons = value; }
        public Creature Gryphons { get => gryphons; set => gryphons = value; }
        public Creature Archers { get => archers; set => archers = value; }
        public Creature Knights { get => knights; set => knights = value; }
        public Creature[] Container { get => container; set => container = value; }


        public Army()
        {
            container = new Creature[4];
            dragons = new Dragon();
            gryphons = new Gryphon();
            archers = new Archer();
            knights = new Knight();
            Container[0] = dragons;
            Container[1] = gryphons;
            Container[2] = archers;
            Container[3] = knights;
        }
        public bool IsEmpty
        {
            get
            {
                if (dragons.Population == 0 && gryphons.Population == 0 && archers.Population == 0 && knights.Population == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
