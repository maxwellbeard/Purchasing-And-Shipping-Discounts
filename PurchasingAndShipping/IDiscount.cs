using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingAndShipping
{
    interface IDiscount
    {
        double calcTieredDiscount();
        double calcFlatDiscount();
    }
}
