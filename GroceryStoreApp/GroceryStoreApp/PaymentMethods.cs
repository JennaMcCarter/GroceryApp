using System;


/*
 * PaymentMethods is the base clas for CreditCards and Cheque. It can be the base class for other classes if needed
 */

namespace GroceryStoreApp
{
    public abstract class PaymentMethods
    {
        abstract public void GetPaymentInformation();

        abstract public void DisplayPaymentInformation();
    }


    public class CreditCard : PaymentMethods
    {
        public string number { get; set; }
        public string expDateMonth { get; set; }
        public string expDateYear { get; set;  }

        //contructor
        public CreditCard()
        {
            this.number = null;
            this.expDateMonth = null;
            this.expDateYear = null;
        }


        //contructor
        public CreditCard(string new_number, string new_expDateMonth, string new_expDateYear)
        {
            this.number = new_number;
            this.expDateMonth = new_expDateMonth;
            this.expDateYear = new_expDateYear;
        }


        //get payment information from the user
        public override void GetPaymentInformation()
        {
            Console.Write("\t\tCredit Card Number: " );
            this.number = Console.ReadLine();
            Console.Write("\t\tExp Date (MM): ");
            this.expDateMonth = Console.ReadLine();
            Console.Write("\t\tExp Date (YYYY): ");
            this.expDateYear = Console.ReadLine();
        }


        //display payment information to the user
        public override void DisplayPaymentInformation()
        {
            Console.WriteLine("Credit Card Number: " + this.number);
            Console.WriteLine("Exp Date : " + this.expDateMonth + "/" + this.expDateYear);
        }

    }

    public class Cheque : PaymentMethods
    {
        public string routingNumber { get; set; }
        public string accountNumber { get; set; }
        public string isChecking { get; set; } //otherwise, savings

        //contructor
        public Cheque()
        {
            this.routingNumber = null;
            this.accountNumber = null;
            this.isChecking = null;
        }

        //contructor
        public Cheque(string new_routingNumber, string new_accountNumber, string new_isChecking)
        {
            this.routingNumber = new_routingNumber;
            this.accountNumber = new_accountNumber;
            this.isChecking = new_isChecking;
        }

        //get payment information from the user
        public override void GetPaymentInformation()
        {
            Console.Write("\t\tRouting Number: ");
            this.routingNumber = Console.ReadLine();
            Console.Write("\t\tAccount Number : ");
            this.accountNumber = Console.ReadLine();
            Console.Write("\t\tIs Savings or Checking: ");
            this.isChecking = Console.ReadLine();
        }

        //display payment information to the user
        public override void DisplayPaymentInformation()
        {
            Console.WriteLine("Routing Number: ");
            Console.WriteLine("Account Number: ");
            Console.WriteLine(this.isChecking);
        }
    }
}
