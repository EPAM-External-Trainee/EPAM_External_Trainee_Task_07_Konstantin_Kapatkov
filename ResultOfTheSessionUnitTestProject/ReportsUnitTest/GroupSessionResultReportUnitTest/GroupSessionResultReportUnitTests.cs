using BLL.Reports.Enums;
using BLL.Reports.Excel;
using BLL.Reports.Models.ReportData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ResultOfTheSessionUnitTestProject.ReportsUnitTest
{
    /// <summary>Class describes functionality for testing <see cref="GroupSessionResultReport"/> class</summary>
    [TestClass]
    public class GroupSessionResultReportUnitTests : ReportsUnitTestData
    {
        public static GroupSessionResultReport Report { get; } = new GroupSessionResultReport(ConnectionString);

        [TestMethod]
        public void GroupSessionResultReport_Test()
        {
            ExcelWriter.WriteToExcel(Report.GetReport(), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_GroupName_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.GroupName, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_GroupName_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.GroupName, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_MaxAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MaxAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_MaxAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MaxAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_MinAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MinAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_MinAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MinAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_AvgAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.AvgAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_AvgAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.AvgAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_AssessmentDynamicsTable_OrderBy_Subject_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(AssessmentDynamicsTableOrderBy.Subject, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_AssessmentDynamicsTable_OrderByDescending_Subject_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(AssessmentDynamicsTableOrderBy.Subject, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(false)]
        public void GroupSessionResultReport_AssessmentDynamicsTable_OrderBy_AverageAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(AssessmentDynamicsTableOrderBy.AverageAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(true)]
        public void GroupSessionResultReport_AssessmentDynamicsTable_OrderByDescending_AverageAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(AssessmentDynamicsTableOrderBy.AverageAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }
    }
}