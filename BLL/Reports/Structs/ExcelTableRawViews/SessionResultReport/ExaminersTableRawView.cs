using BLL.Reports.Interfaces.SessionResultReport;

namespace BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport
{
    public struct ExaminersTableRawView : IExaminersTableRawView
    {
        public string ExaminerSurname { get; set; }

        public string ExaminerName { get; set; }

        public string ExaminerPatronymic { get; set; }

        public string AverageAssessment { get; set; }
    }
}