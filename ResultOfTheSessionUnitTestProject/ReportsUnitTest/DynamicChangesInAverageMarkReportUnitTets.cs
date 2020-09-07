using BLL.Reports.Enums;
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
            AssessmentDynamicsReport report = new AssessmentDynamicsReport(ConnectionString);
            ExcelWriter.WriteToExcel(report.GetReportData(AssessmentDynamicsReportOrderBy.AverageAssessment, false), PathToGroupSessionResultReportExcelFile);
        }
    }
}