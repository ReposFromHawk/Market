using Market.Checkout.Interfaces;

namespace Market.Checkout.Domains
{
    public class CheckOut : ICheckout
    {
        public int GetTotalPrice()
        {
            return 0;
        }

        public void Scan(string v)
        {
            string read = v;
        }
    }
}
