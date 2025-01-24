using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Checkout.Domains
{
    public class PriceRule
    {
        public PriceRule(string sku, int specialQuantity, int specialPrice)
        {
            _sku = sku;
            _specialPrice = specialPrice;
            _specialQuantity = specialQuantity;
        }
        private string _sku;
        private int _specialPrice;
        private int _specialQuantity;

        public string Sku { get { return _sku; } }
        public int SpecialQuantity { get { return _specialQuantity; } }
        public int SpecialPrice { get { return _specialPrice; } }
    }
}
