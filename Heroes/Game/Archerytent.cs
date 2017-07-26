using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Archerytent : CreaturesDwelling
    {
        public Archerytent(Player own) : base("Archerytent", "Allows you to recruit archers", "Archerytent.jpg", "Archer", "Archer.png")
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
        override public Resources RecruitmentCost { get => Owner.PlayerArmy.Archers.Expense; }

        public override void Produce()
        {
            if (this.Level > 0)
            {
                if (Actualamount.Troops < Capacity.Troops)
                    Actualamount.Troops++;

            }
        }

        public override void Getresources(Resources amount)
        {
            if (this.Level > 0)
            {
                var r = new Resources(Owner.PlayerArmy.Archers.Expense);
                r.Multiply(amount.Troops);
                try
                {
                    Owner.Goods.Minus(r);
                    Actualamount.Minus(amount);
                    Owner.PlayerArmy.Archers.AddReinforcements(amount.Troops);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
