using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


/*
 * Inventory.cs keep track of all the items in the grocery store ( a group of Products)
 */

namespace GroceryStoreApp
{
    public class Inventory : ProductsGroup
    {

        //Get data from JSON file and load
        //Could later be changed to a database
        public void LoadInventory()
        {

            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\productList.json";

            //load file
            if (File.Exists(filePath) ? true : false)
            {
                string jsonInput = System.IO.File.ReadAllText(filePath);
                this.ProductsDictionary = JsonConvert.DeserializeObject<Dictionary<int, Products>>(jsonInput);
            }

        }

        //display everything in the inventory
        //can later be changed so it shows only a few at a time (based on what the user wants) so it is not a very long list to go through
        public override void DisplayGroup(string sortBy)
        {
            IOrderedEnumerable<Products> displayDictionary = SortProductDictionary(sortBy);
            int productCount = displayDictionary.Count();

            Console.WriteLine("Item #\t\tItem Name\t\tUnits\t\t# In Stock\tPrice");
            if (productCount > 0)
            {
                foreach (Products item in displayDictionary)
                {
                    item.displayProduct();
                }
            }
            else
            {
                Console.WriteLine("The Store Inventory is currently empty.");
            }
        }

        //remove a product from the inventory
        public override int RemoveProduct(int productId)
        {
            if (this.ProductsDictionary.ContainsKey(productId))
            {
                this.ProductsDictionary.Remove(productId);
                return 1;
            }
            return 0;
        }


        //check if there is enough in the inventory for the user to get something
        public bool ValidateQuantity(int productID, int quantity)
        {
            if (this.ProductsDictionary.ContainsKey(productID))
            {
                Products inventoryItem = this.ProductsDictionary[productID];
                if (inventoryItem.quantity >= quantity)
                {
                    return true;
                }
            }
            return false;
        }

        //when someone adds something to the cart, remove amount from inventory
        public void RemoveFromInventory(int productID, int quantity)
        {
            this.ProductsDictionary[productID].quantity -= quantity;
        }


        //when someone removes something from the cart, add amount to inventory
        public void AddtoInventory(int productID, int quantity)
        {
            this.ProductsDictionary[productID].quantity += quantity;
        }


        //add back to the inventory by sending multiple Products
        public void AddtoInventory(Dictionary<int, Products> listOfItemsToReturn)
        {
            foreach (KeyValuePair<int, Products> item in this.ProductsDictionary)
            {
                this.AddtoInventory(this.ProductsDictionary[item.Key].ID, this.ProductsDictionary[item.Key].quantity);
            }
        }

    }
}
