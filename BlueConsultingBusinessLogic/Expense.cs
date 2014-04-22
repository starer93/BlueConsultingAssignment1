using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class Expense
    {
        public String Location { get; set; }
        public String Description { get; set; }
        public double Amount { get; set; }
        public String Currency { get; set; }
        public int ReportID { get; set; }
        public enum Currencies { AUD, CNY, EUR }; //CHANGE

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

        public void submit()
        {
            var insertCommand = new SqlCommand(@"INSERT Into Expenses (ReportID, Description, Location, Amount, Currency) 
                    VALUES (@ReportID, @Description, @Location, @Amount, @Currency); ; SELECT Scope_Identity();");

            insertCommand.Parameters.Add("@ReportID", SqlDbType.Int).Value = ReportID;
            insertCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            insertCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = Location;
            insertCommand.Parameters.Add("@Amount", SqlDbType.Real).Value = Amount;
            insertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = Currency;

            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.insertToDatabase(insertCommand);
        }
    }
}