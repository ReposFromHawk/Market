using Market.Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market.Checkout.Domains
{
    public class CheckOut : ICheckout
    {
        public CheckOut(List<PriceRule> rules)
        {
            _rules = rules;
            _scannedItems = new Dictionary<string, int>();
        }

        private readonly List<PriceRule> _rules;       


        //Storage for the scanned items
        private readonly Dictionary<string, int> _scannedItems;


        public int GetTotalPrice()
        {
            //Get the total price of the scanned items and sum
            int total = 0;
            foreach (var item in _scannedItems)
            {

                if (_rules.Any(x => x.Sku.Equals(item.Key, StringComparison.OrdinalIgnoreCase)))
                {

                    var rule = _rules.First(s => s.Sku == item.Key);
                    if (rule.SpecialQuantity.HasValue && rule.SpecialPrice.HasValue)
                    {
                        var set = item.Value / rule.SpecialQuantity;
                        var remainder = item.Value % rule.SpecialQuantity;
                        if (rule.SpecialPrice.HasValue && set.HasValue)
                        {
                            total += rule.SpecialPrice.Value * set.Value;
                        }
                        if (remainder > 0)
                        {
                            total += rule.Price * remainder.Value;
                        }
                        continue;
                    }
                    else
                    {
                        total += rule.Price * item.Value;
                    }

                }
            }

            return total;
        }

        public void Scan(string v)
        {

            if (_rules.Any(S => S.Sku.Equals(v, StringComparison.OrdinalIgnoreCase)))
            {
                if (!_scannedItems.ContainsKey(v))
                {
                    _scannedItems[v] = 0;
                }
                _scannedItems[v]++;
            }
            else
            {
                //I wanted to throw a exception.
                //This would be very handy in a real world scenario.
                //ex : Logging
                throw new ArgumentException("Item does not exist");
            }
        }
    }
}
