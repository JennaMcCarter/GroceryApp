using System;



/*
 * This is the basic structure for the program.
 * It keeps looping until the user wants to quit
 * In each loop, the user can decide what they want to do next.
 * Each if statments uses method calls to make this easy to read.
 */





namespace GroceryStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ProgramInterface groceryApp = new ProgramInterface();

            Console.WriteLine("Welcome to Sitka Technology Group eGrocery Store, an online grocery store.\n\n");
            groceryApp.LoadProgram();

            while (groceryApp.continueRunningProgram)
            {
                groceryApp.DisplayMainMenu();
                int userChoice = groceryApp.GetUserInput();
                Console.WriteLine("\n");

                if (userChoice == 1)
                {
                    //view inventory
                    groceryApp.DisplayInventory();
                }
                else if (userChoice == 2)
                {
                    //Display inventory
                    groceryApp.DisplayInventory();
                    //add to cart
                    groceryApp.AddToCart();
                }
                else if (userChoice == 3)
                {
                    //remove item
                    groceryApp.RemoveFromCart();

                }
                else if (userChoice == 4)
                {
                    //Clear Cart
                    groceryApp.ClearCart();

                }
                else if (userChoice == 5)
                {
                    //display cart contents
                    groceryApp.DisplayCart();

                }
                else if (userChoice == 6)
                {
                    //continue to checkout
                    groceryApp.Checkout();

                }
                else if (userChoice == 7)
                {
                    //quit program
                    groceryApp.continueRunningProgram = false;
                }
                else
                {
                    //user types in something that does not match a possible choice
                    Console.WriteLine("This input is not allowed. Please try typing in one number. For example, type in '1' to view inventory.");
                }


                Console.WriteLine("\n\n\n");
            }



        }
    }
}
