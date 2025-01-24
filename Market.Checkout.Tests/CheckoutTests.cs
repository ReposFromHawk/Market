using Market.Checkout.Interfaces;
using Market.Checkout.Domains;
using NUnit.Framework;

namespace Market.Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            var priceRules = new List<PriceRule>
            {
                new PriceRule("A",50, 3, 130),
                new PriceRule("B", 30, 2, 45),
                new PriceRule("C", 20),
                new PriceRule("D", 15)
            };
            _checkout = new CheckOut(priceRules);
        }



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
           
            //Act
            _checkout.Scan(sku);
            int checkoutTotal = _checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected single item A to cost {expectedPrice} but got {checkoutTotal}");
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
           
            //Act
            _checkout.Scan(sku1);
            _checkout.Scan(sku2);
            int checkoutTotal = _checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected price of items to cost {expectedPrice} but got {checkoutTotal}");
        }


        private static readonly object[] _specialOfferCases =
        {
            new object[] { new List<string>{ "A", "A", "A" }, 130 },
            new object[] { new List<string>{ "A", "A"}, 100 },
            new object[] { new List<string> { "A", "A", "A", "A", "A","A"},260 },
            new object[] { new List<string>{ "A","C","B","D", "A", "A" }, 195 },
            new object[] { new List<string>{ "B","C","B","D", "A", "A" }, 180 },
            new object[] { new List<string>{ "B","B","B","D", "A", "A" }, 190 },
        };
        [TestCaseSource(nameof(_specialOfferCases))]
        public void Scan_MultipleSingleSkuItems_ShouldReturnCorrectTotalPrice(IEnumerable<string> skus, int expectedPrice)
        {
            
            //Act
            foreach (var sku in skus)
            {
                _checkout.Scan(sku);
            }
            int checkoutTotal = _checkout.GetTotalPrice();
            //Assert
            Assert.That(expectedPrice == checkoutTotal, $"Expected price of items to cost {expectedPrice} But got {checkoutTotal}");
        }


    }
}
