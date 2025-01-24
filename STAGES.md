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

