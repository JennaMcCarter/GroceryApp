using System.Collections.Generic;
using System.Linq;



/*
 * The ProductsGroup was created as the base class for the Inventory and Cart since they are both collections of Products but do slighlty different things 
 */


namespace GroceryStoreApp
{
    public abstract class ProductsGroup
    {
        protected Dictionary<int, Products> ProductsDictionary;

        //constructor
        public ProductsGroup()
        {
            this.ProductsDictionary = new Dictionary<int, Products>();
        }

        //display contents
        abstract public void DisplayGroup(string sortBy);


        public IOrderedEnumerable<Products> SortProductDictionary(string sortBy)
        {
            if (sortBy.ToLower() == "subtotal")
            {
                return this.ProductsDictionary.Values.OrderBy(x => x.price * x.quantity);
            }
            else if (sortBy.ToLower() == "name")
            {
                return this.ProductsDictionary.Values.OrderBy(x => x.name);
            }
            else
            {
                return this.ProductsDictionary.Values.OrderBy(x => x.ID);
            }
        }




        //remove a Product from the dictionary based on ID
        abstract public int RemoveProduct(int productId);


        //Add a Product
        public void AddProduct(Products product) {
            this.ProductsDictionary.Add(product.ID, product);
        }



        //Clear Dictionary of all Products
        public void ClearGroup()
        {
            this.ProductsDictionary.Clear();
        }



        //check if there is a product with this ID
        public Products getProduct(int productID)
        {
            Products item = new Products();
            if (this.ProductsDictionary.ContainsKey(productID))
            {
                return this.ProductsDictionary[productID];
            }
            return null;
        }

        //get the Products in the collection
        public Dictionary<int, Products> GetProductsDictionary()
        {
            return this.ProductsDictionary;
        }

    }
}
