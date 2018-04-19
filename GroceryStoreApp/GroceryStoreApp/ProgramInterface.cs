using System;
using System.Collections.Generic;

/*
 * This file goes along with the Program.cs file.
 * While Program.cs is the basic structure for the application, this file creates the methods that will be called in Program.cs and
   bring all of the parts of the program together (such as cart, inventory, etc.).
 */


namespace GroceryStoreApp
{
    class ProgramInterface
    {
        public bool continueRunningProgram { get; set; }
        public Inventory storeInventory { get; set; }
        public Cart shoppingCart { get; set; }
        public CreditCard creditcard { get; set; }
        public Cheque cheque { get; set; }

        //contructor
        public ProgramInterface()
        {
            this.continueRunningProgram = true;
            this.storeInventory = new Inventory();
            this.shoppingCart = new Cart();
            this.creditcard = new CreditCard();
            this.cheque = new Cheque();
        }

        
        //this basic choices in the app
        public void DisplayMainMenu()
        {
            Console.WriteLine("Enter the number of the activity you would like to do next: ");
            Console.WriteLine("\t1. View inventory");
            Console.WriteLine("\t2. Add an existing product to your cart");
            Console.WriteLine("\t3. Remove a product from your cart");
            Console.WriteLine("\t4. Clear cart");
            Console.WriteLine("\t5. View cart");
            Console.WriteLine("\t6. Continue to checkout");
            Console.WriteLine("\t7. Quit program");
        }

        
        //get user input and turn into an int which can be used when selecting choices
        //then makes sure it is a number
        public int GetUserInput()
        {
            //userInput is what the user enters and userInputInt is the number version
            //which will beused when checking what the user entered
            string userInput;
            int userInputInt = -1;
            int x = 0;

            Console.Write("\t\tItem Number: ");
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out x))
            {
                userInputInt = Int32.Parse(userInput);
            }
            return userInputInt;
        }


        //load inventory from JSON
        public void LoadProgram()
        {
            this.storeInventory.LoadInventory();
        }


        
        //Add item to cart
        //Gets user input and checks if it exists in the inventory
        //if it does, ask user how many they want
        //if there is enough, remove from inventory and add to cart
        public void AddToCart()
        {
            Console.WriteLine("Which item would you like to add?");
            int userChoice = this.GetUserInput();
            Products inventoryProduct = this.storeInventory.getProduct(userChoice);
            //if item exsists
            if (inventoryProduct != null)
            {
                Console.WriteLine("How many would you like to add?");
                userChoice = this.GetUserInput();
                if (this.storeInventory.ValidateQuantity(inventoryProduct.ID, userChoice))
                {
                    //create new item to add to cart
                    Products cartItem = new Products(inventoryProduct.ID, inventoryProduct.name, inventoryProduct.unitOfMeasure, userChoice, inventoryProduct.price);
                    this.shoppingCart.AddProduct(cartItem);
                    //subtract amount from inventory
                    this.storeInventory.RemoveFromInventory(inventoryProduct.ID, userChoice);
                    Console.WriteLine("Item was added!");
                }
                else
                {
                    Console.WriteLine("There is not enough in the inventory.");
                }
            }
            else
            {
                Console.WriteLine("This item does not exist. Please make sure you typed in the correct ID for the item you would like to add.");
            }

        }


        //remove item from cart and return to inventory
        public void RemoveFromCart()
        {
            Console.WriteLine("What would you like to remove?");
            int userChoice = this.GetUserInput();
            int quantityToAdd = this.shoppingCart.RemoveProduct(userChoice);
            if (quantityToAdd != -1)
            {
                this.storeInventory.AddtoInventory(userChoice, quantityToAdd);
                Console.WriteLine("Item has been removed");
            }
            else
            {
                Console.WriteLine("Item does not exist in your cart");
            }
        }


        //remove everything from the cart and return to inventory
        public void ClearCart()
        {
            Console.WriteLine("Are you sure you would like to empty the cart?");
            Console.WriteLine("\t1. YES");
            Console.WriteLine("\t2. NO");

            int userChoice = this.GetUserInput();
            if (userChoice == 1)
            {
                Dictionary<int, Products> itemsToAddBackToInventory = this.shoppingCart.GetProductsDictionary();
                this.shoppingCart.ClearGroup();
                this.storeInventory.AddtoInventory(itemsToAddBackToInventory);
            }
        }

        //display all Products in the inventory
        public void DisplayInventory()
        {
            this.storeInventory.DisplayGroup("ID");
        }

        //display everything in the cart
        public void DisplayCart()
        {
            Console.WriteLine("How would you like to view your cart?");
            Console.WriteLine("\t1. By Name");
            Console.WriteLine("\t2. By Subtotal");
            int userChoice = GetUserInput();
            if(userChoice == 1)
            {
                this.shoppingCart.DisplayGroup("name");
            }
            else if (userChoice == 2)
            {
                this.shoppingCart.DisplayGroup("subtotal");
            }
            else
            {
                Console.WriteLine("That is not one of the available options.");
            }
        }


        //allow user to go to checkout and get payment information
        public void Checkout()
        {
            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Cheque");
            int userChoice = GetUserInput();
            


            if(userChoice == 1)
            {
                //creditcard
                this.creditcard.GetPaymentInformation();
                Console.WriteLine("You have entered:");
                this.creditcard.DisplayPaymentInformation();
            }
            else if (userChoice == 2)
            {
                //cheque
                this.cheque.GetPaymentInformation();
                Console.WriteLine("You have entered:");
                this.cheque.DisplayPaymentInformation();
            }
            else
            {
                Console.WriteLine("That is not a valid option.");
            }

            if(userChoice == 1 || userChoice == 2)
            {
                Console.WriteLine("Thank you for your purchase.");
                this.shoppingCart.ClearGroup();
            }
        }

    }
}
