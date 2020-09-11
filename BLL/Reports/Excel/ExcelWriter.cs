using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.ExcelViews.ReportViews;
using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BLL.Reports.Excel
{
    public static class ExcelWriter
    {
        private static void SetBorder(ExcelPackage excel, ExcelWorksheet workSheet, string workSheetName)
        {
            workSheet = excel.Workbook.Worksheets[workSheetName];
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }

        private static void SetWorkSheetStyle(ExcelWorksheet workSheet)
        {
            workSheet.TabColor = Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.DefaultColWidth = 20;
        }

        private static void SetRowStyle(ExcelRow row)
        {
            row.Height = 20;
            row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            row.Style.Font.Bold = true;
        }

        private static void WriteGroupTable(IEnumerable<GroupTableView> dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            foreach (var groupTableView in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(groupTableView.GroupName);

                SetWorkSheetStyle(workSheet);
                SetRowStyle(workSheet.Row(currentRow));

                workSheet.Cells[currentRow, currentRow].Value = groupTableView.SessionName;
                workSheet.Cells[currentRow, currentRow, currentRow, groupTableView.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                workSheet.Cells[currentRow, currentRow].Value = $"Group: {groupTableView.GroupName}";
                workSheet.Cells[currentRow, currentRow, currentRow, groupTableView.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                for (int i = 0; i < groupTableView.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = groupTableView.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < groupTableView.TableRawViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = groupTableView.TableRawViews.ToList()[j].Surname;
                    workSheet.Cells[i, 2].Value = groupTableView.TableRawViews.ToList()[j].Name;
                    workSheet.Cells[i, 3].Value = groupTableView.TableRawViews.ToList()[j].Patronymic;
                    workSheet.Cells[i, 4].Value = groupTableView.TableRawViews.ToList()[j].Subject;
                    workSheet.Cells[i, 5].Value = groupTableView.TableRawViews.ToList()[j].Form;
                    workSheet.Cells[i, 6].Value = groupTableView.TableRawViews.ToList()[j].Date;
                    workSheet.Cells[i, 7].Value = groupTableView.TableRawViews.ToList()[j].Assessment;
                }

                SetBorder(excel, workSheet, groupTableView.GroupName);
            }
        }

        private static void WriteSpecialtyAssessmetsTable(SpecialtyAssessmetsTableView dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            int currentRow = 1;
            workSheet = excel.Workbook.Worksheets.Add("Specialty assessments");

            SetWorkSheetStyle(workSheet);
            SetRowStyle(workSheet.Row(currentRow));

            workSheet.Cells[currentRow, currentRow].Value = "Average assessment for each specialty";
            workSheet.Cells[currentRow, currentRow, currentRow, dataToWrite.Headers.Length].Merge = true;

            SetRowStyle(workSheet.Row(++currentRow));

            for (int i = 0; i < dataToWrite.Headers.Length; i++)
            {
                workSheet.Cells[currentRow, ++i].Value = dataToWrite.Headers[--i];
            }

            for (int i = ++currentRow, j = 0; j < dataToWrite.TableRawViews.Count(); i++, j++)
            {
                workSheet.Cells[i, 1].Value = dataToWrite.TableRawViews.ToList()[j].SpecialityName;
                workSheet.Cells[i, 2].Value = dataToWrite.TableRawViews.ToList()[j].AverageAssessment;
            }

            SetBorder(excel, workSheet, "Specialty assessments");
        }

        private static void WriteExaminersTable(ExaminersTableView dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            int currentRow = 1;
            workSheet = excel.Workbook.Worksheets.Add("Examiner assessments");

            SetWorkSheetStyle(workSheet);
            SetRowStyle(workSheet.Row(currentRow));

            workSheet.Cells[currentRow, currentRow].Value = "Average assessment for each examiner";
            workSheet.Cells[currentRow, currentRow, currentRow, dataToWrite.Headers.Length].Merge = true;

            SetRowStyle(workSheet.Row(++currentRow));

            for (int i = 0; i < dataToWrite.Headers.Length; i++)
            {
                workSheet.Cells[currentRow, ++i].Value = dataToWrite.Headers[--i];
            }

            for (int i = ++currentRow, j = 0; j < dataToWrite.TableRawViews.Count(); i++, j++)
            {
                workSheet.Cells[i, 1].Value = dataToWrite.TableRawViews.ToList()[j].ExaminerSurname;
                workSheet.Cells[i, 2].Value = dataToWrite.TableRawViews.ToList()[j].ExaminerName;
                workSheet.Cells[i, 3].Value = dataToWrite.TableRawViews.ToList()[j].ExaminerPatronymic;
                workSheet.Cells[i, 4].Value = dataToWrite.TableRawViews.ToList()[j].AverageAssessment;
            }

            SetBorder(excel, workSheet, "Examiner assessments");
        }

        private static void WriteAssessmentDynamicsTable(AssessmentDynamicsTableView dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            int currentRow = 1;
            workSheet = excel.Workbook.Worksheets.Add("Assessment dynamics");

            SetWorkSheetStyle(workSheet);
            SetRowStyle(workSheet.Row(currentRow));
            workSheet.DefaultColWidth = 25;

            workSheet.Cells[currentRow, currentRow].Value = "Dynamics of changes in the average assessment for each subject by year";
            workSheet.Cells[currentRow, currentRow, currentRow++, dataToWrite.AcademicYears.Count() + 1].Merge = true;

            for (int i = 0; i < dataToWrite.Headers.Length; i++)
            {
                workSheet.Cells[currentRow, ++i].Value = dataToWrite.Headers[--i];
            }

            workSheet.Cells[currentRow, currentRow - 1, currentRow + 1, currentRow - 1].Merge = true;
            workSheet.Cells[currentRow, currentRow - 1, currentRow + 1, currentRow - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[currentRow, currentRow - 1, currentRow + 1, currentRow - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[currentRow, currentRow - 1, currentRow + 1, currentRow - 1].Style.Font.Bold = true;

            workSheet.Cells[currentRow, currentRow, currentRow , currentRow + 1].Merge = true;
            workSheet.Cells[currentRow, currentRow, currentRow, currentRow + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[currentRow, currentRow, currentRow, currentRow + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[currentRow, currentRow, currentRow, currentRow].Style.Font.Bold = true;

            for (int i = currentRow, j = currentRow + 1, k = 0; k < dataToWrite.AcademicYears.Count(); i++, k++)
            {
                workSheet.Cells[j, i].Value = dataToWrite.AcademicYears.ToList()[k];
                workSheet.Cells[j, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[j, i].Style.Font.Bold = true;
            }

            for (int i = currentRow += 2, k = 0; k < dataToWrite.TableRowViews.Count(); i++, k++)
            {
                workSheet.Cells[i, 1].Value = dataToWrite.TableRowViews.ToList()[k].SubjectName;
                for (int j = 0, l = 2; j < dataToWrite.TableRowViews.ToList()[k].AvgAssessments.ToList().Count; j++, l++)
                {
                    workSheet.Cells[i, l].Value = dataToWrite.TableRowViews.ToList()[k].AvgAssessments.ToList()[j] == -1 ? "" : (object)dataToWrite.TableRowViews.ToList()[k].AvgAssessments.ToList()[j];
                    workSheet.Cells[i, l].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
            }

            SetBorder(excel, workSheet, "Assessment dynamics");
        }

        private static void WriteGroupSessionResultTable(IEnumerable<GroupSessionResultTableView> dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            foreach (var table in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(table.AcademicYear);

                SetWorkSheetStyle(workSheet);
                SetRowStyle(workSheet.Row(currentRow));

                workSheet.Cells[currentRow, currentRow].Value = table.SessionName;
                workSheet.Cells[currentRow, currentRow, currentRow, table.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                for (int j = 0; j < table.Headers.Length; j++)
                {
                    workSheet.Cells[currentRow, ++j].Value = table.Headers[--j];
                }

                for (int k = ++currentRow, j = 0; j < table.TableRowViews.Count(); k++, j++)
                {
                    workSheet.Cells[k, 1].Value = table.TableRowViews.ToList()[j].GroupName;
                    workSheet.Cells[k, 2].Value = table.TableRowViews.ToList()[j].MaxAssessment;
                    workSheet.Cells[k, 3].Value = table.TableRowViews.ToList()[j].MinAssessment;
                    workSheet.Cells[k, 4].Value = table.TableRowViews.ToList()[j].AvgAssessment;
                }

                SetBorder(excel, workSheet, table.AcademicYear);
            }
        }

        public static void WriteToExcel(SessionResultReportView dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            WriteGroupTable(dataToWrite.GroupTables, excel, workSheet);
            WriteSpecialtyAssessmetsTable(dataToWrite.SpecialtyAssessmetsTable, excel, workSheet);
            WriteExaminersTable(dataToWrite.ExaminersTable, excel, workSheet);

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm?.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());

            excel?.Dispose();
            workSheet?.Dispose();
        }

        public static void WriteToExcel(GroupSessionResultReportView dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            WriteGroupSessionResultTable(dataToWrite.GroupSessionResultTables, excel, workSheet);
            WriteAssessmentDynamicsTable(dataToWrite.AssessmentDynamicsTable, excel, workSheet);

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm?.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());

            excel?.Dispose();
            workSheet?.Dispose();
        }
    }
}