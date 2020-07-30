using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PurchasingAndShipping
{
    class Purchasing : Item
    {
        private int[] tierSizes;
        private double[] tierPercentages;

        public Purchasing(string id, string name, int quantity, double price, int[] tierSizes, double[] tierPercentages)
            : base(id, name, quantity, price)
        {
            this.tierSizes = tierSizes;
            this.tierPercentages = tierPercentages;
        }

        public override string ToString()
        {
            return base.ToString() + $": cost {priceOrDist:C}, quantity {quantity}" + 
                $"\nDiscount options:" + 
                $"\n   {tierSizes[0]} at {tierPercentages[0]:f2} %, {tierSizes[1]} at {tierPercentages[1]:f2} %, {tierSizes[2]} at {tierPercentages[2]:f2} %";
        }

        public double getGrossCost() => cost;

        public override double calcFlatDiscount()
        {
            double discount = cost * 0.1;
            WriteLine($"Whole cart discount: {discount:C}");
            return discount;
        }

        public override double calcTieredDiscount()
        {
            double discount, percent;
            if(quantity > tierSizes[0]) {
                discount = cost * (tierPercentages[0] / 100);
                percent = tierPercentages[0];
            } else if (quantity > tierSizes[1]) {
                discount = cost * (tierPercentages[1] / 100);
                percent = tierPercentages[1];
            } else if (quantity > tierSizes[2]) {
                discount = cost * (tierPercentages[2] / 100);
                percent = tierPercentages[2];
            } else {
                discount = 0;
                percent = 0;
            }
            WriteLine($"Volume rate: {percent:f2} %, discount: {discount:C}");
            return discount;
        }
    }
}
