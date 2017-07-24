using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Dragonshatchery : Building
    {
        public Dragonshatchery(Player own) : base("Dragonshatchery", "TODO", "Dragonshatchery.png")
        {
            this.Level = 1;
            this.Maxlevel = 1;
            this.Capacity = new Resources(0, 0, 0, 0, 4);
            this.Actualamount = new Resources();
            this.Owner = own;
        }

        public override void Produce()
        {
            if (Actualamount.Troops < Capacity.Troops)
            {
                Actualamount.Troops++;
                Owner.Goods.Minus(Owner.PlayerArmy.Dragons.Expense);
            }
        }

        public override void Getresources()
        {
            Owner.PlayerArmy.Dragons.AddReinforcements(Actualamount.Troops);
            Actualamount.Zero();
        }

    }
}
