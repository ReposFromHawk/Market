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
        private readonly Dictionary<string, int> _scannedItems;
        public CheckOut() { _scannedItems = new Dictionary<string, int>(); }

        public int GetTotalPrice()
        {
            int total = 0;
            foreach (var item in _scannedItems)
            {
                total += _itemPrices[item.Key] * item.Value;
            }
            return total;
        }

        public void Scan(string v)
        {
            if (!_scannedItems.ContainsKey(v))
            {
                _scannedItems[v] = 0;
            }
            _scannedItems[v]++;
        }
    }
}
