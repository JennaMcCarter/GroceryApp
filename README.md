# GroceryApp
I created a simple Product class which I then used to create ProductGroups, which is basically a dictionary of Products. I did this because the cart and the inventory are basically a groups of Products. And, they would share similar methods such as display. In a bigger application, they would share other methods such as add, remove, and delete. 

I chose to create ProductGroup with a dictionary (with the product ID as the key) to make it easier to find and select particular items without have through multiple items to find it. I chose to use the ID because I needed a unique key to store and locate the products.

ProductGroup is an abstract class because it will not be used anywhere else other than to create Cart and Inventory.


I used the same technique with PaymentMethods to create the CreditCard class and the Cheque class. In a bigger program, payment and checkout would involve a lot more to ensure security and validation before the user hits submit.

ProgramInterface was created as a way to bring all the different classes together to create the basic actions the user can complete while the Program.cs file is use to create the structure.


### Requirements
"The Grocery Store"
Non-Functional Requirements:
* Console or terminal application in a language of your choosing.

Functional Requirements:
* Display menu of available commands.
* Allow input of "grocery product" into a cart.
* Grocery products have these attributes:
  * Name, Unit of Measure, Quantity, Price
* Allow listing products in cart.
  * This should show a subtotal per line (quantity * price)
  * User should be allowed to sort by Name or subtotal.
* Support adding and removing items in cart.
* Support clearing cart.
* Support checkout.
  * Devise a way to present payment methods and input information appropriate to the selected method.
