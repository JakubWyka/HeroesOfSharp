using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Townhall : Building
    {
        public Townhall(Player own) : base("Townhall", "TODO", "Townhall.jpg")
        {
            this.Level = 1;
            this.Maxlevel = 5;
            this.Levelupcost = new Resources(30,30,30,30,0);
            this.Capacity = new Resources(0, 0, 0, 100,0);
            this.Actualamount = new Resources();
            this.Actualproductivity= new Resources(0, 0, 0, 1,0);
            this.Levelprodbonus= new Resources(0, 0, 0, 1,0);
            this.Capacitylevbonus = new Resources(0, 0, 0, 50,0);
            this.Owner = own;
        }
    }
}
