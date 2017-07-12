using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Wood : Building
    {
        public Wood(Player own)
        { 
            this.Level = 1;
            this.Maxlevel = 5;
            this.Levelupcost = new Resources(40,40,40,40);
            this.Capacity = new Resources(100, 0, 0, 0);
            this.Actualamount = new Resources();
            this.Actualproductivity= new Resources(1, 0, 0, 0);
            this.Levelprodbonus= new Resources(1, 0, 0, 0);
            this.Capacitylevbonus = new Resources(50, 0, 0, 0);
            this.Owner = own;
        }
    }
}
