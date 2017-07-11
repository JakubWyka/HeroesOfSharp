using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfSharp
{
    class Resources
    {
        int wood;
        int clay;//glina
        int ore;//ruda
        int gold;

        public int Gold { get => gold; set => gold = value; }
        public int Clay { get => clay; set => clay = value; }
        public int Wood { get => wood; set => wood = value; }
        public int Ore { get => ore; set => ore = value; }

        public Resources(int w, int c, int o, int g)
        {
            wood = w;
            clay = c;
            ore = o;
            gold = g;
        }
        public Resources()
        {
            wood = 0;
            clay = 0;
            ore = 0;
            gold = 0;
        }
        public void Minus(Resources re)
        {
            wood -= re.Wood;
            clay -= re.Clay;
            gold -= re.Gold;
            ore -= re.Ore;
        }
        public void Plus(Resources re)
        {
            wood -= re.Wood;
            clay -= re.Clay;
            gold -= re.Gold;
            ore -= re.Ore;
        }
        public void Zero()
        {
            wood = 0;
            clay = 0;
            gold = 0;
            ore = 0;
        }
        public void Limit(Resources max)
        {
            if(wood>max.Wood)
                wood = max.Wood;
            if (clay > max.Clay)
                clay = max.Clay;
            if (gold > max.Gold)
                gold = max.Gold;
            if (ore > max.Ore)
                ore = max.Ore;
        }
    }
}
