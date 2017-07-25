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
            this.Levelupcost = new Resources(70, 70, 70, 70, 0);
            this.Actualproductivity = new Resources(0, 0, 0, 0, 0);
            this.Levelprodbonus = new Resources(0, 0, 0, 0, 0);
            this.Capacitylevbonus = new Resources(0, 0, 0, 0, 0);
            this.Owner = own;
        }

        public override void Produce()
        {
            if (this.Level > 0)
            {
                if (Actualamount.Troops < Capacity.Troops)
                {
                    Actualamount.Troops++;
                    Owner.Goods.Minus(Owner.PlayerArmy.Archers.Expense);
                }
            }
        }

        public override void Getresources()
        {
            if (this.Level > 0)
            {
                Owner.PlayerArmy.Archers.AddReinforcements(Actualamount.Troops);
                Actualamount.Zero();
            }
        }
    }
}
