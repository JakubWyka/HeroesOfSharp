using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Townhall : Building
    {
        public Townhall(Player own)
        {
            this.Level = 1;
            this.Maxlevel = 5;
            this.Levelupcost = new Resources(30,30,30,30);
            this.Capacity = new Resources(0, 0, 0, 100);
            this.Actualamount = new Resources();
            this.Actualproductivity= new Resources(0, 0, 0, 1);
            this.Levelprodbonus= new Resources(0, 0, 0, 1);
            this.Capacitylevbonus = new Resources(0, 0, 0, 50);
            this.Owner = own;
        }
    }
}
