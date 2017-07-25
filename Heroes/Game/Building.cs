using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Game
{
    abstract public class Building : GameObject
    {
        int level;
        int maxlevel;
        Resources capacity;//max przechowywane
        Resources actualamount;//przechowywane
        Resources actualproductivity;//produkcja 
        Resources levelprodbonus;
        Resources capacitylevbonus;
        Resources levelupcost;
        Player owner;

        public int Level { get => level; set => level = value; }
        public int Maxlevel { get => maxlevel; set => maxlevel = value; }
        internal Resources Capacity { get => capacity; set => capacity = value; }
        internal Resources Actualamount { get => actualamount; set => actualamount = value; }
        internal Resources Actualproductivity { get => actualproductivity; set => actualproductivity = value; }
        internal Resources Levelprodbonus { get => levelprodbonus; set => levelprodbonus = value; }
        public Resources Levelupcost { get => levelupcost; set => levelupcost = value; }
        internal Player Owner { get => owner; set => owner = value; }
        internal Resources Capacitylevbonus { get => capacitylevbonus; set => capacitylevbonus = value; }

        public Building(String Name, String Description, String FileName) : base(Name, Description, FileName)
        {
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

        public virtual void Produce()//produkowanie do przechowalni kopalni
        {
            Actualamount.Plus(Actualproductivity);
            Actualamount.Limit(Capacity);
        }

        public virtual void Getresources()//opróżnienie budynku, przetransferowanie dobra do uzytkownika
        {
            Owner.Goods.Plus(Actualamount);
            Actualamount.Zero();
        }

    }
}
