using BLL.Reports.Enums;
using BLL.Reports.Excel;
using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.Models;
using BLL.Reports.Models.ReportData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.ReportsUnitTest
{
    [TestClass]
    public class GroupSessionResultReporsUnitTests : ReportsUnitTestData
    {
        [TestMethod]
        public void TestMethod()
        {
            GroupSessionResultReport report = new GroupSessionResultReport(ConnectionString);
            ExcelWriter.WriteToExcel(report.GetReport(), PathToGroupSessionResultReportExcelFile);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //GroupSessionResultTable report = new GroupSessionResultTable(ConnectionString);
            //ExcelWriter.WriteToExcel(report.GetGroupSessionResultTables(), PathToGroupSessionResultReportExcelFile);
        }
    }
}