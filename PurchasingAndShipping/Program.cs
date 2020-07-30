using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PurchasingAndShipping
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("SDEV 2410 Final Project - Purchasing and Shipping by Max Beard\n");
            ArrayList products = new ArrayList();
            ArrayList boxes = new ArrayList();
            double grossCost, tierCost, flatCost;
            double totalGross = 0, totalTierProducts = 0, totalFlatProducts = 0, totalTierBoxes = 0, totalFlatBoxes = 0;

            // instantiation
            products.Add(new Purchasing("P123", "coffee mug", 25, 12.29, new int[] { 50, 30, 15 }, new double[] { 20, 10, 5 }));
            products.Add(new Purchasing("P987", "magnet, large", 10, 3.29, new int[] { 50, 30, 15 }, new double[] { 20, 10, 5 }));
            //products.Add(new Purchasing("P547", "stuffed bear", 100, 11.99, new int[] { 20, 10, 5 }, new double[] { 12, 8, 3 }));
            products.Add(new Purchasing("P879", "note cube", 100, 2.50, new int[] { 150, 100, 50 }, new double[] { 20, 10, 5 }));
            boxes.Add(new Shipping("S678", "Miami FL", 100, 2000, 11.5, 8.5, 4, 5.2));
            boxes.Add(new Shipping("S449", "Chicago IL", 250, 800, 5, 5, 5, 12.3));
            boxes.Add(new Shipping("S721", "Denver CO", 10, 150, 6.5, 6.5, 3, 2.5));
            boxes.Add(new Shipping("S678", "SLC UT", 50, 30, 14, 8, 1, 1.5));

            // Part 1 - Purchasing
            WriteLine("Part 1: Purchasing Products\n");

            // loop through each product and calculate costs and discounts
            foreach(Purchasing p in products) {
                WriteLine(p);
                // get gross cost and display
                grossCost = p.getGrossCost();
                WriteLine($"Cost with no discount: {grossCost:C}");

                // get tiered discount and calculate cost
                tierCost = grossCost - p.calcTieredDiscount();
                WriteLine($"Cost after Volume discount: {(tierCost):C}");

                // get flat discount and calculate cost
                flatCost = grossCost - p.calcFlatDiscount();
                WriteLine($"Cost after cart discount: {(flatCost):C}");

                // add costs to running totals
                totalGross += grossCost;
                totalTierProducts += tierCost;
                totalFlatProducts += flatCost;

                WriteLine();
            }

            // display cost totals
            WriteLine("Summary:");
            WriteLine("Straight Cost:".PadLeft(17) + $" {totalGross:C}");
            WriteLine("Volume Discounts:".PadLeft(17) + $" {totalTierProducts:C}");
            WriteLine("Cart Discount:".PadLeft(17) + $" {totalFlatProducts:C}");

            // Part 2 - Shipping
            WriteLine("\nPart 2 - Shipping Products");

            // loop through each box and calculate costs
            foreach(Shipping s in boxes) {
                WriteLine(s);
                // calculate and display zone rate shipping
                tierCost = s.calcTieredDiscount();

                // calculate and display flat rate shipping
                flatCost = s.calcFlatDiscount();

                // add costs to running totals
                totalTierBoxes += tierCost;
                totalFlatBoxes += flatCost;

                WriteLine();
            }

            // display cost totals
            WriteLine("Summary:");
            WriteLine("Zone shipping costs:".PadLeft(20) + $" {totalTierBoxes:C}");
            WriteLine("Flat rate costs:".PadLeft(20) + $" {totalFlatBoxes:C}");

            // pause
            Write("\nPress any key to continue...");
            ReadKey();
        }
    }
}
