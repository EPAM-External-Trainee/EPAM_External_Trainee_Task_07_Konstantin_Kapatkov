namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews
{
    public interface IExaminersTableRawView
    {
        string ExaminerSurname { get; set; }

        string ExaminerName { get; set; }

        string ExaminerPatronymic { get; set; }

        double AverageAssessment { get; set; }
    }
}