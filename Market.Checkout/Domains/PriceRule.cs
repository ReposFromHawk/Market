using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Checkout.Domains
{
    public class PriceRule
    {
        public PriceRule(string sku, int price, int? specialQuantity = null, int? specialPrice = null)
        {
            _sku = sku;
            _price = price;
            _specialPrice = specialPrice;
            _specialQuantity = specialQuantity;

        }

        private string _sku;
        private int _price;
        private int? _specialPrice;
        private int? _specialQuantity;

        public string Sku { get { return _sku; } }
        public int? SpecialQuantity { get { return _specialQuantity; } }
        public int? SpecialPrice { get { return _specialPrice; } }
        public int Price { get { return _price; } }
    }
}
