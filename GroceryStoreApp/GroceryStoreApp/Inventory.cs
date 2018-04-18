using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


/*
 * This is the 
 */

namespace GroceryStoreApp
{
    public class Inventory : ProductsGroup
    {


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

        public void RemoveFromInventory(int productID, int quantity)
        {
            this.ProductsDictionary[productID].quantity -= quantity;
        }

        public void AddtoInventory(int productID, int quantity)
        {
            this.ProductsDictionary[productID].quantity += quantity;
        }

        public void AddtoInventory(Dictionary<int, Products> listOfItemsToReturn)
        {
            foreach (KeyValuePair<int, Products> item in this.ProductsDictionary)
            {
                this.AddtoInventory(this.ProductsDictionary[item.Key].ID, this.ProductsDictionary[item.Key].quantity);
            }
        }

    }
}
