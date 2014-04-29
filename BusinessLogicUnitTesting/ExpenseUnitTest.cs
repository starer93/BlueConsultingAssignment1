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
            //tests the Expense constructor and getters

            //define test data
            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.AUD.ToString();

            //instantiate test object
            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;

            //compare test data to test object
            Assert.AreEqual(expense.Location, testLocation);
            Assert.AreEqual(expense.Description, testDescription);
            Assert.AreEqual(expense.Amount, testAmount);
            Assert.AreEqual(expense.Currency, testCurrency);
        }

        [TestMethod]
        public void testExpenseDatabaseInsertionAndRetrieval()
        {
            //tests the expense's ability to insert and retrieve itself to the database

            //define test data
            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.AUD.ToString();
            string testReportID = "1000";

            //instantiate test object
            List<Report> testReports = new List<Report>();
            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;
            expense.ReportID = testReportID;
            List<Expense> expenses = new List<Expense>();
            expenses.Add(expense);
            expenses.Add(expense);

<<<<<<< HEAD

            DatabaseAccess da = new DatabaseAccess("BusinessLogicUnitTesting.Properties.Settings.DATABASEMyConnection");
            //start transaction
=======
            
            // start transaction
            DatabaseAccess da = new DatabaseAccess("BusinessLogicUnitTesting.Properties.Settings.DATABASEMyConnection");
>>>>>>> c25f06e9ea4893cd8f6dccf3e9d4740752dd4bb4
            using (TransactionScope testTransaction = new TransactionScope())
            {
                //submit test object to database
                foreach (Expense currentExpense in expenses)
                {
                    da.submitExpense(currentExpense.ReportID, currentExpense.Description, currentExpense.Location, currentExpense.Amount, currentExpense.Currency);
                }

                //retrieve test object from database
                List<Expense> retrievedExpenses = Expense.GetExpensesFromDBByReportID(testReportID);

                //compare the retrieved object to the test data
                foreach (Expense retrievedExpense in retrievedExpenses)
                {
                    Assert.AreEqual(retrievedExpense.Location, testLocation);
                    Assert.AreEqual(retrievedExpense.Description, testDescription);
                    Assert.AreEqual(retrievedExpense.Amount, testAmount);
                    Assert.AreEqual(retrievedExpense.Currency, testCurrency);
                }

                //Roll back the transaction
                testTransaction.Dispose();
            }
        }

        [TestMethod]
        public void testPrintExpense()
        {
            //tests the expense's ability to print its data to a formatted string

            //define test data
            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.AUD.ToString();
            string testReportID = "1000";

            //instantiate test object
            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;
            expense.ReportID = testReportID;

            //compare the returned data to the test data
            string expectedString = String.Format("{0}, {1}, {2}, {3}, {4}\n", testLocation, testDescription, testAmount, testCurrency, testReportID);
            Assert.IsTrue(expectedString.Equals(expense.PrintExpense()));
        }

        [TestMethod]
        public void testExpenseCurrencyConversion()
        {
            //tests the expense's ability to print its data to a formatted string

            //define test data
            string testLocation = "Sydney";
            string testDescription = "Airfare: Sydney to Tokyo";
            double testAmount = 2497.0;
            string testCurrency = Expense.Currencies.CNY.ToString();
            string testReportID = "1000";
            double conversionRate = Expense.CNY_CONVERTION_RATE;

            //instantiate test object
            Expense expense = new Expense();
            expense.Location = testLocation;
            expense.Description = testDescription;
            expense.Amount = testAmount;
            expense.Currency = testCurrency;
            expense.ReportID = testReportID;

            //compare the returned data to the expected data
            double expectedConvertedAmount = testAmount * conversionRate;
            double returnedConvertedAmount = expense.calculateExpenseInAUD();
            Assert.AreEqual(expectedConvertedAmount, returnedConvertedAmount);


            //update test data for next test
            testAmount = 1201.0;
            testCurrency = Expense.Currencies.EUR.ToString();
            conversionRate = Expense.EUR_CONVERTION_RATE;

            //update test object with updated test data
            expense.Amount = testAmount;
            expense.Currency = testCurrency;

            //compare the returned data to the expected data
            expectedConvertedAmount = testAmount * conversionRate;
            returnedConvertedAmount = expense.calculateExpenseInAUD();
            Assert.AreEqual(expectedConvertedAmount, returnedConvertedAmount);


            //update test data for next test
            testAmount = 609.0;
            testCurrency = Expense.Currencies.AUD.ToString();
            conversionRate = 1.0;

            //update test object with updated test data
            expense.Amount = testAmount;
            expense.Currency = testCurrency;

            //compare the returned data to the expected data
            expectedConvertedAmount = testAmount * conversionRate;
            returnedConvertedAmount = expense.calculateExpenseInAUD();
            Assert.AreEqual(expectedConvertedAmount, returnedConvertedAmount);
        }

    }
}
