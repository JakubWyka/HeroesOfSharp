using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Dragonshatchery : CreaturesDwelling
    {
        public Dragonshatchery(Player own) : base("Dragonshatchery", "TODO", "Dragonshatchery.png", "Dragon", "Dragon.png")
        {
            this.Level = 0;
            this.Maxlevel = 1;
            this.Capacity = new Resources(0, 0, 0, 0, 4);
            this.Actualamount = new Resources();

            this.Levelupcost = new Resources(50,50,50,50,0);
            this.Actualproductivity = new Resources(0, 0, 0, 0, 0);
            this.Levelprodbonus = new Resources(0, 0, 0, 0, 0);
            this.Capacitylevbonus = new Resources(0, 0, 0, 0, 0);
            this.Owner = own;           
        }
        override public Resources RecruitmentCost { get => Owner.PlayerArmy.Dragons.Expense; }

        public override void Produce()
        {
            if (this.Level > 0)
            {
                if (Actualamount.Troops < Capacity.Troops)
                {
                    Actualamount.Troops++;
                    Owner.Goods.Minus(Owner.PlayerArmy.Dragons.Expense);
                }
            }
        }

        public override void Getresources()
        {
            if (this.Level > 0)
            {
                Owner.PlayerArmy.Dragons.AddReinforcements(Actualamount.Troops);
                Actualamount.Zero();
            }
        }

    }
}
