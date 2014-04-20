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
        public int ReportID { get; set; }

        public Expense(String location, String description, double amount, String currency, int reportID)
        {
            this.Location = location;
            this.Description = description;
            this.Amount = amount;
            this.Currency = currency;
            this.ReportID = reportID;
        }

        public Expense()
        {

        }

        public String PrintExpense()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}\n", Location, Description, Amount, Currency, ReportID);
        }

        public double getAmount()
        {
            return Amount;
        }
    }
}