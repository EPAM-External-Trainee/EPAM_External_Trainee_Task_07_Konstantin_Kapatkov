using System;
using BLL.Reports.Abstract;
using BLL.Reports.Excel;
using BLL.Reports.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.ReportsUnitTest
{
    [TestClass]
    public class DynamicChangesInAverageMarkReportUnitTets : ReportsUnitTestData
    {
        [TestMethod]
        public void TestMethod()
        {
            DynamicChangesInAverageMarkReport report = new DynamicChangesInAverageMarkReport(ConnectionString);
            ExcelWriter.WriteToExcel(report.GetReportData(), PathToGroupSessionResultReportExcelFile);
        }
    }
}
