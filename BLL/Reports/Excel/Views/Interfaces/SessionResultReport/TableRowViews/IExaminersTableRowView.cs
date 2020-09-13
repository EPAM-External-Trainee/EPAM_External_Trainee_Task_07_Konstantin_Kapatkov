namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews
{
    /// <summary>Interface describing the row view of the examiners table</summary>
    public interface IExaminersTableRowView
    {
        /// <summary>Examiner surname</summary>
        string ExaminerSurname { get; set; }

        /// <summary>Examiner name</summary>
        string ExaminerName { get; set; }

        /// <summary>Examiner patronymic</summary>
        string ExaminerPatronymic { get; set; }

        /// <summary>Examiner average assessment</summary>
        double ExaminerAverageAssessment { get; set; }
    }
}