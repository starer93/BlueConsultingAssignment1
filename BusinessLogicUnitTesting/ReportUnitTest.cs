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
    public class ReportUnitTest
    {
        [TestMethod]
        public void testReportConstructorAndGetters()
        {
            string consultantID = "testPerson";
            string reportID = "100000";
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string reportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            //string filepath = "testLoadRecieptPDF";       
            //Image PDF = Image.FromFile(filepath);

            Report report = new Report();

            report.ConsultantID = consultantID;
            report.ReportID = reportID;           
            report.Date = date;
            report.ReportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            //report.Receipt = PDF;
                  
            Assert.AreEqual(consultantID, report.ConsultantID);
            Assert.AreEqual(reportID, report.ReportID);
            Assert.AreEqual(date, report.Date);
            Assert.AreEqual(reportStatus, report.ReportStatus);
            //Assert.AreEqual(PDF, report.PDF);
        }

    }
}
