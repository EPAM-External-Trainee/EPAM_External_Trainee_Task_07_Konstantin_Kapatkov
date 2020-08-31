namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IExaminersTableRawView
    {
        string ExaminerSurname { get; set; }

        string ExaminerName { get; set; }

        string ExaminerPatronymic { get; set; }

        string AverageAssessment { get; set; }
    }
}