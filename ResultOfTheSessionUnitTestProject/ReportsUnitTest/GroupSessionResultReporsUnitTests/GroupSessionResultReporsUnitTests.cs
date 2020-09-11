using BLL.Reports.Excel;
using BLL.Reports.Models.ReportData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ResultOfTheSessionUnitTestProject.ReportsUnitTest
{
    [TestClass]
    public class GroupSessionResultReporsUnitTests : ReportsUnitTestData
    {
        [TestMethod]
        public void GroupSessionResultReport_Test()
        {
            GroupSessionResultReport report = new GroupSessionResultReport(ConnectionString);
            ExcelWriter.WriteToExcel(report.GetReport(), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //GroupSessionResultTable report = new GroupSessionResultTable(ConnectionString);
            //ExcelWriter.WriteToExcel(report.GetGroupSessionResultTables(), PathToGroupSessionResultReportExcelFile);
        }
    }
}