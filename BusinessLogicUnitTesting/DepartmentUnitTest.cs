using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueConsultingBusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicUnitTesting
{
    [TestClass]
    public class DepartmentUnitTest
    {
        DatabaseAccess da = new DatabaseAccess("BusinessLogicUnitTesting.Properties.Settings.DATABASEMyConnection");

        [TestMethod]
        public void testDepartmentConstructor()
        {
            //tests the department's constructors, which involves retrieving reports from a database

            //define test data
            int testDepartmentIndex = 0; //0 Is the index of the State Services department
            string testExpectedDepartmentName = "State Services";

            //instantiate test object
            Department department = new Department(testDepartmentIndex, da);
            department.databaseAccess = da;

            //compare test data to test object
            Assert.AreEqual(testExpectedDepartmentName, department.Name);
        }

        public void testDepartmentReportGetters()
        {
            //tests the department's report getter methods. 

            //define test data
            int testDepartmentIndex = 2; //2 Is the index of the Higher Education department
            string testMonth = "April";
            string testYear = "2014";
            string testReportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            double testExpectedFirstExpense = 4000;
            //instantiate test object
            Department department = new Department(testDepartmentIndex, da);
            List<Report> reports = department.getDepartmentReports(testMonth, testYear);
            department.databaseAccess = da;

            //compare test data to test object
            Assert.IsTrue(reports.Count > 0);
            Assert.AreEqual(reports.First().calculateExpenseInAUD(), testExpectedFirstExpense);

            //update the test object
            reports = department.getDepartmentReports(testMonth, testYear, testReportStatus);

            //compare test data to test object
            Assert.IsTrue(reports.Count > 0);
            Assert.AreEqual(reports.First().calculateExpenseInAUD(), testExpectedFirstExpense);

            //modify the test data
            testReportStatus = Report.ReportStatuses.RejectedByAccountStaff.ToString();

            //update the test object
            reports = department.getDepartmentReports(testMonth, testYear, testReportStatus);

            //compare test data to test object
            Assert.IsTrue(reports.Count == 0);
        }

        public void testDepartmentBudgetGetters()
        {
            //tests the department's budget getter and calculation methods 

            //define test data
            int testDepartmentIndex = 2; //2 Is the index of the Higher Education department
            double testExpectedMonthlyBudget = 10000;
            double testExpectedRemainingBudget = 6000;
            double testExpectedTotalExpense = 4000;
            string testMonth = "April";
            string testYear = "2014";

            //instantiate test object
            Department department = new Department(testDepartmentIndex, da);
            List<Report> reports = department.getDepartmentReports(testMonth, testYear);
            Report report = reports.First();

            //compare test data to test object
            Assert.AreEqual(testExpectedMonthlyBudget, department.getTotalBudget());//If this assert fails, first check the const MONTHLY_BUDGET in Department has not changed from 10000;
            Assert.AreEqual(testExpectedRemainingBudget, department.getRemainingBudget(testMonth, testYear));
            Assert.AreEqual(testExpectedTotalExpense, department.TotalExpense(testMonth, testYear));
            Assert.IsFalse(department.willBeOverBudget(report));

            //update test uobject
            Expense expense = report.GetExpenses().First();
            report.AddExpense(expense);

            //compare test data to test object
            Assert.IsTrue(department.willBeOverBudget(report));

        }
    }


    
}
