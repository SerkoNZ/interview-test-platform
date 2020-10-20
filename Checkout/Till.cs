using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {

        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0}
        };

        public double Total() 
        { 
            double total = 0;
            double noOfItemsC = 0;
            foreach(var item in _items)
            {
                if(item.Key.Equals('A') || item.Key.Equals('B'))
                {
                    //total += 50 * item.Value;
                    total += DiscountItems(item.Value.ToString(), item)
                }
                else if(item.Key.Equals('C'))
                {
                    total = AddItemC(total, item, noOfItemsC);
                }
                else total = AddItemD(total, item);
            } 
           return total;
        }

static double AddItemD(double total, KeyValuePair<char, int> item)
{
    if (item.Key.Equals('D'))
    {
        total += 15 * item.Value;
    }

    return total;
}

        private static double AddItemC(double total, KeyValuePair<char, int> item, double noOfItemsC)
        {
            if(noOfItemsC <= 6)
            {
                total += 15 * item.Value;
            }
            return total;
        }


        public double DiscountItems(string numberItems, KeyValuePair<char, int> nameItems)
        {
            double items = Double.Parse(numberItems);
            var cost = 0
            if(items == 0) return 0;

            if(nameItems.Key.Equals(‘A’))
            {
                cost = items * 50;
                var itemADiscount = items / 3;

                //discount is 20 on every three items
                var discount = itemADiscount * 20
                cost -=  discount
            }

            else if(nameItems.Key.Equals(‘B’))
            {
                cost = items * 30;
                var numberOfPairs = items / 2;

                //discount is 15 on each pair
                var discount = numberOfPairs * 15
                cost -= discount
            }

            return cost

        }
        //This is your original code
//         private static double AddItemC(double total, KeyValuePair<char, int> item)
//         {
//             if (item.Key.Equals('C'))
//             {
//                 total += 15 * item.Value;
//             }

//             return total;
//         }

//         public double AddB(string numberItems)
//         {
//             double items = Double.Parse(numberItems);

//             if(items == 0) return 0;

//             var cost = items * 30;
//                 var numberOfPairs =  items / 2;

//             // discount is 15 on each pair
//             var discount = numberOfPairs * 15;
//             return cost - discount;
//         }
        

        public void Scan(string items)
        {
            foreach(var item in items)
            {
                _items[item]++;  
            }
        }
    }
}
