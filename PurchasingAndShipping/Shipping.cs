using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PurchasingAndShipping
{
    class Shipping : Item
    {
        private static double[] tierDistance = { 1000, 500, 100 };
        private static double[] tierCost = { 50, 35, 20 };
        private double length;
        private double width;
        private double height;
        private double weight;

        public Shipping(string id, string destination, int quantity, double distance, double length, double width, double height, double weight)
            : base(id, destination, quantity, distance)
        {
            this.length = length;
            this.width = width;
            this.height = height;
            this.weight = weight;
        }

        public override string ToString()
        {
            return base.ToString() + $": {quantity} boxes, distance {priceOrDist} miles" +
                $"\nSize: {length} x {width} x {height}, weight: {weight}" +
                $"\nZone rate:" + 
                $"\n   {tierDistance[0]} mi at {tierCost[0]:C}, {tierDistance[1]} mi at {tierCost[1]:C}, {tierDistance[2]} mi at {tierCost[2]:C}";
        }

        public override double calcFlatDiscount()
        {
            double cost =  quantity * tierCost[1];
            WriteLine($"Flat rate cost: {cost:C}");
            return cost;
        }

        public override double calcTieredDiscount()
        {
            double cost, rate;
            if(priceOrDist > tierDistance[0]) {
                cost = quantity * tierCost[0];
                rate = tierCost[0];
            } else if (priceOrDist > tierDistance[1]) {
                cost = quantity * tierCost[1];
                rate = tierCost[1];
            } else if (priceOrDist > tierDistance[2]) {
                cost = quantity * tierCost[2];
                rate = tierCost[2];
            } else {
                cost = quantity * 10;
                rate = 10;
            }
            WriteLine($"Zone rate: {rate:C}, ship cost: {cost:C}");
            return cost;
        }
    }
}
