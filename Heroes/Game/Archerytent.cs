using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Archerytent : Building
    {
        public Archerytent(Player own) : base("Archerytent", "TODO", "Archerytent.jpg")
        {
            this.Level = 0;
            this.Maxlevel = 1;         
            this.Capacity = new Resources(0, 0, 0, 0, 7);
            this.Actualamount = new Resources();
            this.Owner = own;
        }

        public override void Produce()
        {
            if (Actualamount.Troops < Capacity.Troops)
            {
                Actualamount.Troops++;
                Owner.Goods.Minus(Owner.PlayerArmy.Archers.Expense);
            }
        }

        public override void Getresources()
        {
            Owner.PlayerArmy.Archers.AddReinforcements(Actualamount.Troops);
            Actualamount.Zero();
        }
    }
}
