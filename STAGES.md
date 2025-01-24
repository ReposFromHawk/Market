**STEP 0:**

Create the project structure and add it to a git repo.

In pure TDD, we have to write a test that references methods on an interface or class that doesn't exist yet.
This results in natural fail since it won't be compiled.
So :

**STEP 1:**

I created an test "Scaning a Single Item like A should Return Price of it".
After Create the interface and complete defining the methods and properties required for the interface in MarketCheckout Project.
The same test defines the interface and also  requires to define and discover the instance of the implementation of the interface resulting as a class.


**STEP 2:**

After definition and general discoveries of the entities completed, we have a compiling project.
Run the tests and we get 

 Scan_SingleItemA_ShouldReturnPriceOf50
   Source: CheckoutTests.cs line 14
   Duration: 16 ms

  Message: 
System.NotImplementedException : The method or operation is not implemented.
Stack Trace: 
CheckOut.Scan(String v) line 14
CheckoutTests.Scan_SingleItemA_ShouldReturnPriceOf50() line 19
RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)

Check Point.

After complete the basic implementationof the methods:
Run Tests and Result as follows:

 Scan_SingleItemA_ShouldReturnPriceOf50
   Source: CheckoutTests.cs line 14
   Duration: 33 ms

  Message: 
  Expected single item A to cost 50
  Assert.That(50 == checkoutTotal, Is.True)
  Expected: True


**STEP 3:**


Now we discovered that we need to find the price of scanned SKU.
So prices should come from somewhere else and our system should find prices based on SKUs.
Therefor I added the logic to return 50 for SKU A which is hard coded.
This will pass the test.
Since this is the first passing test, and the logic is decoupled, the next stages shouldn't fail this test for successul development process.

**STEP 4**

We need to scan multiple items. There for I create a test to see if multiple item scans work and their sums are correct.
The first test will scan A and B respectively and the GetTotalPrice is expected to return 80.

The first run resulted as follows:

 Scan_MultipleItems_A_B_ShouldReturnPriceOf80
   Source: CheckoutTests.cs line 32
   Duration: 20 ms

  Message: 
  Expected price of items to cost 80
Assert.That(80 == checkoutTotal, Is.True)
  Expected: True
  But was:  False

  So after this we need to refactor this.

**STEP 5**

Internally we created a dictionary to store items' prices.
After scanning the items, we saw that the related test past.
Scan_MultipleItems_A_B_ShouldReturnPriceOf80

**STEP 6**

Refactor first tests not to use hard coded values.
We should be able to test with multiple cases.

**STEP 7**

We need to implement the sku multiple pricing feature.
It works in rule basis.
Like an item have a differenrt price with condition of n sales number.
Example is ;
3 A Sums as 130
2 B Sums as 45

So I created a test for single special offers.

Scan_MultipleSingleSkuItems_ShouldReturnCorrectToatalPrice

With Given Cases Results as Follows :

       { "A", "A", "A" }, 130 }             FAILED
       { "A", "A"}, 100 }                   PASS
       { "A", "A", "A", "A", "A","A"},260 } FAILED

Now We need to fix this.


In Spec it is given that :
    1. Pricing rules change frequently,
    2. There is a requirement to be able to pass pricing rules each time before scanning starts.
    This should be able to handle special offers per sku.

A PriceRule class added to solution as soon as we wanted to pass this to Checkout constructor in last test.
So tests fail now.
We are again in the Red stage.

After this stage again Some Previous tests with no rule related ones are passing the tests. But Rule Related Tests are failing.

Now when I run the tests, the following results shown :

   Source: CheckoutTests.cs line 64
   Duration: 23 ms

  Message: 
  Expected price of items to cost 130
Assert.That(expectedPrice == checkoutTotal, Is.True)
  Expected: True
  But was:  False

Scan_MultipleSingleSkuItems_ShouldReturnCorrectTotalPrice(System.Collections.Generic.List`1[System.String],260)
   Source: CheckoutTests.cs line 64
   Duration: < 1 ms

  Message: 
  Expected price of items to cost 260
Assert.That(expectedPrice == checkoutTotal, Is.True)
  Expected: True
  But was:  False

**STEP 8**

I added a SETUP section for the tests.
I initialized the PriceRules as a list of PriceRule.
So in the list I added the given prices for special quantities.

var priceRules = new List<PriceRule>
            {
                new PriceRule("A", 3, 130),
                new PriceRule("B", 2, 45)

            };

Since PriceRule class don't have any properties and constructors, the compilor fails.So requiredproperties are created at this stage.


**STEP 9**


Time to implement price calculations based on rules.

Price Rules Now Implemented and Related Test for the Scenario Past.


**STEP 10**


A few edge cases added for tests.

REFACTORING AND EXTENDING THE CODE

1. I think, rather then the pricing hard coded, we can add it to the pricing rule. This will be a better solution.
 In Setup section of Tests I made this change to trigger a refactoring cycle:

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
            _checkout = new Checkout(priceRules);
        }
        
        So it fails to compile now.

In this stage Pricing Rules now contains the standard prices and all calculations look correct.
