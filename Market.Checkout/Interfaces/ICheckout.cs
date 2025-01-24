using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Checkout.Interfaces
{
    public interface ICheckout
    {
        int GetTotalPrice();
        void Scan(string v);
    }
}
