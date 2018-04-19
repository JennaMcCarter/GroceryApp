using System;
using System.Linq;


/*
 * Cart.cs represents the object that hold and keeps track of what the user wants to buy 
 */


namespace GroceryStoreApp
{
    public class Cart : ProductsGroup
    {


        //display the contents of the cart based 
        public override void DisplayGroup(string sortBy)
        {
            //sort items in the cart
            IOrderedEnumerable<Products> displayDictionary = SortProductDictionary(sortBy);
            double subtotal = 0.0;
            double total = 0.0;
            int itemInCart = displayDictionary.Count();

            //if there is something to display
            if (itemInCart > 0)
            {
                Console.WriteLine("Item #\t\tItem Name\t\tUnits\t\t# In Stock\tPrice");
                foreach (Products item in displayDictionary)
                {
                    item.displayProduct();
                    subtotal = item.price * item.quantity;
                    total += subtotal;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\tsubtotal: $" + subtotal);
                }
                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\ttotal: $" + total);
            }
            else
            {
                Console.WriteLine("You cart is empty");
            }
        }



        //remove a Product from the dictionary based on ID
        public override int RemoveProduct(int productId)
        {
            int quantityToRemove = -1;
            if (this.ProductsDictionary.ContainsKey(productId))
            {
                quantityToRemove = this.ProductsDictionary[productId].quantity;
                this.ProductsDictionary.Remove(productId);
            }
            return quantityToRemove;
        }
    }
}
