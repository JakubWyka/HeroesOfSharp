using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Resources
    {
        int wood;
        int clay;//glina
        int ore;//ruda
        int gold;
        int troops;

        public int Gold { get => gold; set => gold = value; }
        public int Clay { get => clay; set => clay = value; }
        public int Wood { get => wood; set => wood = value; }
        public int Ore { get => ore; set => ore = value; }
        public int Troops { get => troops; set => troops = value; }

        public Resources(int w, int c, int o, int g, int t)
        {
            wood = w;
            clay = c;
            ore = o;
            gold = g;
            troops = t;
        }

        public Resources(Resources r)
        {
            wood = r.Wood;
            clay = r.Clay;
            ore = r.Ore;
            gold = r.Gold;
            troops = r.Troops;
        }
        public Resources()
        {
            wood = 0;
            clay = 0;
            ore = 0;
            gold = 0;
            Troops = 0;
        }
        public void Minus(Resources re)
        {
            if (re.Wood > wood || re.Clay > clay || re.gold > gold || re.Ore > ore)
                throw new Exception("Not enough recources");
            else
            {
                wood -= re.Wood;
                clay -= re.Clay;
                gold -= re.Gold;
                ore -= re.Ore;
            }

            Troops -= re.Troops;
        }
        public void Plus(Resources re)
        {
            wood += re.Wood;
            clay += re.Clay;
            gold += re.Gold;
            ore += re.Ore;
            Troops += re.Troops;
        }
        public void Zero()
        {
            wood = 0;
            clay = 0;
            gold = 0;
            ore = 0;
            troops = 0;
        }
        public void Limit(Resources max)
        {
            if (wood > max.Wood)
                wood = max.Wood;
            if (clay > max.Clay)
                clay = max.Clay;
            if (gold > max.Gold)
                gold = max.Gold;
            if (ore > max.Ore)
                ore = max.Ore;
            if (troops > max.Troops)
                troops = max.Troops;
        }
        public void Multiply(int num)
        {
            wood = wood * num;
            clay = clay * num;
            gold = gold * num;
            ore = ore * num;
            troops = troops * num;
        }
    }
}
