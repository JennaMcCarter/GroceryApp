using System;

/*
 * This is the Products class
 * In the grocery store app, this is what each of the products will have the following properties
 */

namespace GroceryStoreApp
{
    public class Products
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string unitOfMeasure { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }


        //constructor
        public Products()
        {
            this.ID = 0;
            this.name = null;
            this.unitOfMeasure = null;
            this.quantity = 0;
            this.price = 0.0;
        }


        //constructor
        public Products(int new_Id, string new_name, string new_unitOfMeasure, int new_quantity, double new_price)
        {
            this.ID = new_Id;
            this.name = new_name;
            this.unitOfMeasure = new_unitOfMeasure;
            this.quantity = new_quantity;
            this.price = new_price;
        }

        //displays to the user information about the products
        public void displayProduct()
        {
            Console.WriteLine(
                        this.ID + "\t\t" +
                        this.name + "\t\t\t" +
                        this.unitOfMeasure + "\t\t" +
                        this.quantity + "\t\t" +
                        "$" + this.price);
        }
    }
}
