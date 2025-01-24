using Market.Checkout.Interfaces;
using Market.Checkout.Domains;
using NUnit.Framework;

namespace Market.Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        //This is the first failing test for the checkout.
        //Entry point the define the Interface.
        //Since the Interface actually is suggested, I wanted to show that we can still start with tdd to determine the interface.
        [Test]
        public void Scan_SingleItemA_ShouldReturnPriceOf50()
        {
            //Arrange            
            ICheckout checkout = new CheckOut(); //This is the interface first definition which fails as not existing.
            //Act
            checkout.Scan("A");
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(50 == checkoutTotal, "Expected single item A to cost 50");
        }

    }
}
