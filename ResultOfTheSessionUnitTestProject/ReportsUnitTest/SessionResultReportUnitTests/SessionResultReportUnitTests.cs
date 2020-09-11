using BLL.Reports.Excel;
using BLL.Reports.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.ReportsUnitTest;
using System.IO;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class SessionResultReportUnitTests : ReportsUnitTestData
    {
        [TestMethod]
        [DataRow(1)]
        public void SessionResultReport_Test(int sessionId)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            ExcelWriter.WriteToExcel(sessionResultForGroup.GetReport(sessionId), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }
    }
}