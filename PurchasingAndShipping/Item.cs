using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingAndShipping
{
    abstract class Item : IDiscount
    {
        private string id;
        private string nameOrDest;
        protected int quantity;
        protected double priceOrDist;
        protected double cost;

        public Item(string id, string nameOrDest, int quantity, double priceOrDist)
        {
            this.id = id;
            this.nameOrDest = nameOrDest;
            this.quantity = quantity;
            this.priceOrDist = priceOrDist;
            this.cost = quantity * priceOrDist;
        }

        public override string ToString()
        {
            return id + " " + nameOrDest;
        }

        public abstract double calcTieredDiscount();

        public abstract double calcFlatDiscount();
    }
}
