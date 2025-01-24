using Market.Checkout.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Market.Checkout.Domains
{
    public class CheckOut : ICheckout
    {

        //We need to know the individual prices for the items.
        //So Create a dictionary of the items and their prices
        private Dictionary<string, int> _itemPrices = new Dictionary<string, int>()
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };


        //Storage for the scanned items
        ICollection<string> _scannedItems;
        public CheckOut() { _scannedItems = new List<string>(); }

        public int GetTotalPrice()
        {
            int total = 0;
            foreach (var item in _scannedItems)
            {
                total += _itemPrices[item];
            }
            return total;
        }

        public void Scan(string v)
        {
            _scannedItems.Add(v);
        }
    }
}
