using Market.Checkout.Interfaces;
using Market.Checkout.Domains;
using NUnit.Framework;

namespace Market.Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        /// <summary>
        /// This is the first failing test for the checkout.
        ///  Entry point the define the Interface.
        ///  Since the Interface actually is suggested, I wanted to show that we can still start with tdd to determine the interface.
        /// </summary>
        [Test]
        public void Scan_SingleItemA_ShouldReturnPriceOf50()
        {
            //Arrange            
            ICheckout checkout = new CheckOut();
            //Act
            checkout.Scan("A");
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(50 == checkoutTotal, "Expected single item A to cost 50");
        }

        /// <summary>
        /// This is the second test for the checkout.
        /// I will implement the scan for multiple items and see if it works.
        /// </summary>
        [Test]
        public void Scan_MultipleItems_A_B_ShouldReturnPriceOf80()
        {
            //Arrange            
            ICheckout checkout = new CheckOut();
            //Act
            checkout.Scan("A");
            checkout.Scan("B");
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(80 == checkoutTotal, "Expected price of items to cost 80");
        }

    }
}
