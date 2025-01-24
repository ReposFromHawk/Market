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
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void Scan_SingleItem_ShouldReturnItsPriceCorrectPrice(string sku, int expectedPrice)
        {
            //Arrange            
            ICheckout checkout = new CheckOut(); 
            //Act
            checkout.Scan(sku);
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected single item A to cost {expectedPrice}");
        }


        private static readonly object[] _singlePriceCases =
        {
            new object[] { "A", "B", 80 },
            new object[] { "A", "C", 70 },
            new object[] { "B", "D", 45}
        };


        /// <summary>
        /// This is the second test for the checkout.
        /// I will implement the scan for multiple items and see if it works.
        /// </summary>
        [TestCaseSource(nameof(_singlePriceCases))]
        public void Scan_MultipleItems_ShouldReturnCorrectTotalPrice(string sku1, string sku2, int expectedPrice)
        {
            //Arrange            
            ICheckout checkout = new CheckOut();
            //Act
            checkout.Scan(sku1);
            checkout.Scan(sku2);
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected price of items to cost {expectedPrice}");
        }


        private static readonly object[] _specialOfferCases =
        {
            new object[] { new List<string>{ "A", "A", "A" }, 130 },
            new object[] { new List<string>{ "A", "A"}, 100 },
            new object[] { new List<string> { "A", "A", "A", "A", "A","A"},260 }
        };
        [TestCaseSource(nameof(_specialOfferCases))]
        public void Scan_MultipleSingleSkuItems_ShouldReturnCorrectTotalPrice(IEnumerable<string> skus, int expectedPrice)
        {
            //Arrange            
            ICheckout checkout = new CheckOut();
            //Act
            foreach (var sku in skus)
            {
                checkout.Scan(sku);
            }
            int checkoutTotal = checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected price of items to cost {expectedPrice}");
        }


    }
}
