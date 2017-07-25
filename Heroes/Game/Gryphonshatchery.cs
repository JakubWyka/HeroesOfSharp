using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Gryphonshatchery : Building
    {
        public Gryphonshatchery(Player own) : base("Gryphonshatchery", "TODO", "Gryphonshatchery.jpg")
        {
            this.Level = 0;
            this.Maxlevel = 1;
            this.Capacity = new Resources(0, 0, 0, 0, 3);
            this.Actualamount = new Resources();
            this.Levelupcost = new Resources(100, 100, 100, 100, 0);
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
                    Owner.Goods.Minus(Owner.PlayerArmy.Gryphons.Expense);
                }
            }
        }

        public override void Getresources()
        {
            if (this.Level > 0)
            {
                Owner.PlayerArmy.Gryphons.AddReinforcements(Actualamount.Troops);
                Actualamount.Zero();
            }
        }
    }
}
