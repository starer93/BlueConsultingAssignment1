using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Drawing;
using BlueConsultingBusinessLogic;
namespace BusinessLogicUnitTesting
{
    [TestClass]
    class ReportUnitTest
    {
        [TestMethod]
        public void testReportConstructorAndGetters()
        {
            string consultantID = "testPerson";
            string reportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            string filepath = "testLoadRecieptPDF";       
            Image PDF = Image.FromFile(filepath);
            Report report = new Report("", consultantID, "100000", reportStatus, System.DateTime.Today.ToShortDateString(), PDF);           
            Assert.Equals(consultantID, report.ConsultantID);
            Assert.Equals(reportStatus, report.ReportStatus);
            Assert.AreEqual(PDF, report.PDF);
        }

        //[TestMethod]
       // public void ;
    }
}
