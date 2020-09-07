using BLL.Reports.Excel;
using BLL.Reports.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.ReportsUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class SessionResultReportUnitTests : ReportsUnitTestData
    {
        [TestMethod]
        public void SessionResultReport_Test()
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            ExcelWriter.WriteToExcel(sessionResultForGroup.GetReportData(1), PathToSessionResultReportExcelFile);
        }
    }
}