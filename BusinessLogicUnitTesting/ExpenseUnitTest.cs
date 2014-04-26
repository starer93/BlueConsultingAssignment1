using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueConsultingBusinessLogic;
using System.Transactions;
using System.Data;

namespace BusinessLogicUnitTesting
{
    [TestClass]
    public class ExpenseUnitTest
    {       
        [TestMethod]
        public void testExpenseConstructorAndProperties()
        {
            //Tests the Expense constructor and getters
            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.AUD.ToString();

            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;

            Assert.AreEqual(expense.Location, testLocation);
            Assert.AreEqual(expense.Description, testDescription);
            Assert.AreEqual(expense.Amount, testAmount);
            Assert.AreEqual(expense.Currency, testCurrency);
        }

        [TestMethod]
        public void testExpenseDatabaseInsertionAndRetrieval()
        {
            List<Report> testReports = new List<Report>();
            string testConsultantID = "testPerson";
            //ConsultantLogic consultant = new ConsultantLogic(testConsultantID);

            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.AUD.ToString();
            string testReportID = "1000";

            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;
            expense.ReportID = testReportID;

            List<Expense> expenses = new List<Expense>();
            expenses.Add(expense);
            expenses.Add(expense);

            
            // start transaction
            DatabaseAccess da = new DatabaseAccess();
            using (TransactionScope testTransaction = new TransactionScope())
            {
                foreach (Expense currentExpense in expenses)
                {
                    da.submitExpense(currentExpense.ReportID, currentExpense.Description, currentExpense.Location, currentExpense.Amount, currentExpense.Currency);
                }                              
                
                List<Expense> retrievedExpenses = Expense.GetExpensesFromDBByReportID(testReportID);
                foreach(Expense retrievedExpense in retrievedExpenses)
                {
                    Assert.AreEqual(retrievedExpense.Location, testLocation);
                    Assert.AreEqual(retrievedExpense.Description, testDescription);
                    Assert.AreEqual(retrievedExpense.Amount, testAmount);
                    Assert.AreEqual(retrievedExpense.Currency, testCurrency);
                    //Assert.IsTrue(insertedExpenseID > 0);
                }

                //Roll back the transaction
                testTransaction.Dispose();
                
               
            }
             
        }
         
         
    }
}
