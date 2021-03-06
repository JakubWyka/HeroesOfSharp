﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Game
{
    public class Claypit : Mine
    {
        public Claypit(Player own) : base("Claypit", "Produces clay", "Claypit.png")
        { 
            this.Level = 0;
            this.Maxlevel = 5;
            this.Levelupcost = new Resources(50,50,50,50,0);
            this.Capacity = new Resources(0, 100, 0, 0,0);
            this.Actualamount = new Resources();
            this.Actualproductivity= new Resources(0, 1, 0, 0,0);
            this.Levelprodbonus= new Resources(0, 1, 0, 0,0);
            this.Capacitylevbonus = new Resources(0, 50, 0, 0,0);
            this.Owner = own;
        }
}
}
