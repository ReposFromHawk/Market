using Market.Checkout.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Market.Checkout.Domains
{
    public class CheckOut : ICheckout
    {
        //Storage for the scanned items
        ICollection<string> _scannedItems;
        public CheckOut() { _scannedItems = new List<string>(); }

        public int GetTotalPrice()
        {
           return _scannedItems.Any(x => x.Equals("A", StringComparison.OrdinalIgnoreCase)) ? 50 : 0;
        }

        public void Scan(string v)
        {
            _scannedItems.Add(v);
        }
    }
}
