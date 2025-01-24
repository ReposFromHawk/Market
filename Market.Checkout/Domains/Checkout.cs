using Market.Checkout.Interfaces;

namespace Market.Checkout.Domains
{
    public class CheckOut : ICheckout
    {
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string v)
        {
            throw new NotImplementedException();
        }
    }
}
