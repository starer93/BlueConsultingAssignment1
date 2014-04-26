﻿using System;
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
        public string ReportID { get; set; }
        public enum Currencies { AUD, CNY, EUR }; //CHANGE

        public Expense(String location, String description, double amount, String currency, string reportID)
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
            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.submitExpense(ReportID, Description, Location, Amount, Currency);
        }

        public static List<Expense> GetExpensesFromDBByReportID(string reportID)
        {
            DatabaseAccess da = new DatabaseAccess();
            DataTable dataTable = da.GetExpensesByReportID(reportID);
            List<Expense> expenses = new List<Expense>();

            foreach (DataRow row in dataTable.Rows)
            {
                Expense expense = new Expense();
                expense.Amount = (double)row["Amount"];
                expense.Currency = row["Currency"].ToString();
                expense.Description = row["Description"].ToString();
                expense.Location = row["Location"].ToString();
                expense.ReportID = row["ReportID"].ToString();
                //.Receipt = (byte[])row["Receipt"];
                expenses.Add(expense);
            }
            return expenses;
        }
    }
}