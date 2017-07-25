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
            this.Owner = own;
        }

        public override void Produce()
        {
            if (Actualamount.Troops < Capacity.Troops)
            {
                Actualamount.Troops++;
                Owner.Goods.Minus(Owner.PlayerArmy.Gryphons.Expense);
            }
        }

        public override void Getresources()
        {
            Owner.PlayerArmy.Gryphons.AddReinforcements(Actualamount.Troops);
            Actualamount.Zero();
        }
    }
}
