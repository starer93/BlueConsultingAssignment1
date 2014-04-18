using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BlueConsultingBusinessLogic
{
    public class Expense
    {
        public String Location { get; set; }
        public String Description { get; set; }
        public double Amount { get; set; }
        public String Currency { get; set; }
        public String ReportID { get; set; }

        public Image Receipts { get; set; } //later on, this will need to store multiple receipts

        public Expense(String location, String description, double amount, String currency, Image receipts)
        {
            //new expense
            this.Location = location;
            this.Description = description;
            this.Amount = amount;
            this.Currency = currency;
            this.Receipts = receipts; //later on, this will need to store multiple receipts
        }

        public Expense()
        {
        }

        public String PrintExpense()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}\n", Location, Description, Amount, Currency, Receipts);
        }

        public double getAmount()
        {
            return Amount;
        }
    }
}
