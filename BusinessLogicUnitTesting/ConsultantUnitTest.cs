using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueConsultingBusinessLogic;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLogicUnitTesting
{
    [TestClass]
    public class ConsultantUnitTest
    {

        [TestMethod]
        public void testConsultantDatabaseRetrieval()
        {
            //tests the Consultant's ability to load his reports from the database

            //define test data
            string testConsultantID = "aaa";
            string testFirstReportID = "51"; //based on the state of the database at the time of writing this test. If the test fails, update this variable
            DatabaseAccess da = new DatabaseAccess("BusinessLogicUnitTesting.Properties.Settings.DATABASEMyConnection");

            //instantiate test object
            ConsultantLogic consultant = new ConsultantLogic(testConsultantID, da);
            List<Report> reports = new List<Report>();
            reports = consultant.GetReports();
            Report firstReport = reports.First();

            //compare test data to test object
            Assert.AreEqual(testFirstReportID, firstReport.ReportID); //if this test fails, first check the state of the reports table in the database to see if the first report belonging to aaa is still 51.
        }

        [TestMethod]
        public void testConsultantFindReportAndAddReport()
        {
            //tests the Consultant's ability to add reports and search for reports

            //define test data
            string testConsultantID = "aaa";
            string testFirstReportID = "51"; //based on the state of the database at the time of writing this test. If the test fails, update this variable
            DatabaseAccess da = new DatabaseAccess("BusinessLogicUnitTesting.Properties.Settings.DATABASEMyConnection");

            //instantiate test object
            ConsultantLogic consultant = new ConsultantLogic(testConsultantID, da);
            List<Report> reports = new List<Report>();
            reports = consultant.GetReports();
            Report firstReport = reports.First();
            Report foundReport = consultant.findReport(testFirstReportID);

            //compare test data to test object
            Assert.AreEqual(firstReport, foundReport);

            //update test data
            int originalReportsSize = reports.Count;

            //update test object
            consultant.addReport(firstReport);
            reports = consultant.GetReports();

            //compare test data to test object
            Assert.AreNotEqual(originalReportsSize, reports.Count);

        }

        [TestMethod]
        public void testConsultantDoesntCrashWhenConsultantNotFound()
        {
            //tests whether providing the consultant constructor with a false id will crash the program

            //define test data
            string consultantID = "fakePerson";

            //instantiate test object
            ConsultantLogic consultant = new ConsultantLogic(consultantID);

            //the test will automatically fail if an unhandled exception is thrown. If the test passes, the exception was handled
        }
    }
}