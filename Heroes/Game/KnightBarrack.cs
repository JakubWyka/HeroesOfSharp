using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Knightbarrack : CreaturesDwelling
    {
        public Knightbarrack(Player own) : base("Knightbarrack", "TODO", "Knightbarrack.jpg", "Knight", "Knight.png")
        {
            this.Level = 0;
            this.Maxlevel = 1;
            this.Capacity = new Resources(0, 0, 0, 0, 5);
            this.Actualamount = new Resources();
            this.Levelupcost = new Resources(120, 120, 120, 120, 0);
            this.Actualproductivity = new Resources(0, 0, 0, 0, 0);
            this.Levelprodbonus = new Resources(0, 0, 0, 0, 0);
            this.Capacitylevbonus = new Resources(0, 0, 0, 0, 0);
            this.Owner = own;
        }
        override public Resources RecruitmentCost { get => Owner.PlayerArmy.Knights.Expense; }

        public override void Produce()
        {
            if (this.Level > 0)
            {
                if (Actualamount.Troops < Capacity.Troops)
                {
                    Actualamount.Troops++;
                    Owner.Goods.Minus(Owner.PlayerArmy.Knights.Expense);
                }
            }
        }

        public override void Getresources()
        {
            if (this.Level > 0)
            {
                Owner.PlayerArmy.Knights.AddReinforcements(Actualamount.Troops);
                Actualamount.Zero();
            }
        }
    }
}
