using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Knightbarrack : Building
    {
        public Knightbarrack(Player own) : base("Knightbarrack", "TODO", "Knightbarrack.jpg")
        {
            this.Level = 0;
            this.Maxlevel = 1;
            this.Capacity = new Resources(0, 0, 0, 0, 5);
            this.Actualamount = new Resources();
            this.Owner = own;
        }

        public override void Produce()
        {
            if (Actualamount.Troops < Capacity.Troops)
            {
                Actualamount.Troops++;
                Owner.Goods.Minus(Owner.PlayerArmy.Knights.Expense);
            }
        }

        public override void Getresources()
        {
            Owner.PlayerArmy.Knights.AddReinforcements(Actualamount.Troops);
            Actualamount.Zero();
        }
    }
}
