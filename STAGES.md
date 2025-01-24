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