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
        public static SessionResultReport Report = new SessionResultReport(ConnectionString);

        [TestMethod]
        [DataRow(2)]
        public void SessionResultReport_Test(int sessionId)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Assessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Assessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Assessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Assessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Date_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Date, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Date_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Date, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Form_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Form, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Form_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Form, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Name_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Name, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Name_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Name, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Surname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Surname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Surname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Surname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Patronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Patronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Patronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Patronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Subject_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Subject, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Subject_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Subject, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_ExaminersTable_OrderBy_AverageAssessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerAverageAssessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_ExaminersTable_OrderByDesceding_AverageAssessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerAverageAssessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_ExaminersTable_OrderBy_ExaminerName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_ExaminersTable_OrderByDesceding_ExaminerName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_ExaminersTable_OrderBy_ExaminerSurname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerSurname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_ExaminersTable_OrderByDesceding_ExaminerSurname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerSurname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_ExaminersTable_OrderBy_ExaminerPatronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerPatronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_ExaminersTable_OrderByDesceding_ExaminerPatronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.ExaminerPatronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_SpecialtyAssesmentsTable_OrderBy_SpecialityName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.SpecialityName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_SpecialtyAssesmentsTable_OrderByDesceding_SpecialityName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.SpecialityName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, false)]
        public void SessionResultReport_SpecialtyAssesmentsTable_OrderBy_SpecialityAverageAssessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.SpecialityAverageAssessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [TestMethod]
        [DataRow(1, true)]
        public void SessionResultReport_SpecialtyAssesmentsTable_OrderByDesceding_SpecialityAverageAssessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.SpecialityAverageAssessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }
    }
}