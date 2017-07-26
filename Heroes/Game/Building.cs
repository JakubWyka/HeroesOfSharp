using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Game
{
    abstract public class Building : GameObject
    {
        protected int level;
        protected int maxlevel;
        protected long _LastProduce;
        protected long _Interval;
        protected Resources capacity;//max przechowywane
        protected Resources actualamount;//przechowywane
        protected Resources actualproductivity;//produkcja 
        protected Resources levelprodbonus;
        protected Resources capacitylevbonus;
        protected Resources levelupcost;
        protected Player owner;

        public int Level { get => level; set => level = value; }
        public int Maxlevel { get => maxlevel; set => maxlevel = value; }
        public Resources Capacity { get => capacity; set => capacity = value; }
        public Resources Actualamount { get => actualamount; set => actualamount = value; }
        internal Resources Actualproductivity { get => actualproductivity; set => actualproductivity = value; }
        internal Resources Levelprodbonus { get => levelprodbonus; set => levelprodbonus = value; }
        public Resources Levelupcost { get => levelupcost; set => levelupcost = value; }
        internal Player Owner { get => owner; set => owner = value; }
        internal Resources Capacitylevbonus { get => capacitylevbonus; set => capacitylevbonus = value; }
        public long LastProduce { get => _LastProduce; set => _LastProduce = value; }
        public long Interval { get => _Interval; }
        public Building(String Name, String Description, String FileName) : base(Name, Description, FileName)
        {
            _Interval = 5;
        }

        public void Levelup()
        {
            try
            {
                if (this.Level < Maxlevel)
                {
                    Owner.Goods.Minus(Levelupcost);
                    this.Level++;
                    Actualproductivity.Plus(Levelprodbonus);
                    Capacity.Plus(Capacitylevbonus);
                    Levelupcost.Multiply(2);
                }
                else
                    throw new IndexOutOfRangeException("Level is already max");
            }
            catch
            {
                throw;
            }
        }

        abstract public void Produce();//produkowanie do przechowalni kopalni

        abstract public void Getresources();//opróżnienie budynku, przetransferowanie dobra do uzytkownika
    }
}
