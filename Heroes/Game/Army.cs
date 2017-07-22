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
        Creature[] conteiner;

        public Creature Dragons { get => dragons; set => dragons = value; }
        public Creature Gryphons { get => gryphons; set => gryphons = value; }
        public Creature Archers { get => archers; set => archers = value; }
        public Creature Knights { get => knights; set => knights = value; }
        public Creature[] Conteiner { get => conteiner; set => conteiner = value; }


        public Army()
        {
            conteiner = new Creature[4];
              dragons = new Dragon();
            gryphons = new Gryphon();
            archers = new Archer();
            knights = new Knight();
            Conteiner[0] = dragons;
            Conteiner[1] = gryphons;
            Conteiner[2] = archers;
            Conteiner[3] = knights;
        }
    }
}
