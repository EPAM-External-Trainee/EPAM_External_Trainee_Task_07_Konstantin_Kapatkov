using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.SessionResultReport
{
    /// <summary>Struct describing the row view of the examiners table</summary>
    public struct ExaminersTableRowView : IExaminersTableRowView
    {
        /// <summary>Creating an instance of <see cref="ExaminersTableRowView"/> via examiner surname, name, patronymic and average assessment</summary>
        /// <param name="examinerSurname">Examiner surname</param>
        /// <param name="examinerName">Examiner name</param>
        /// <param name="examinerPatronymic">Examiner patronymic</param>
        /// <param name="averageAssessment">Average assessment</param>
        public ExaminersTableRowView(string examinerSurname, string examinerName, string examinerPatronymic, double averageAssessment)
        {
            ExaminerSurname = examinerSurname;
            ExaminerName = examinerName;
            ExaminerPatronymic = examinerPatronymic;
            ExaminerAverageAssessment = averageAssessment;
        }

        /// <inheritdoc cref="IExaminersTableRowView.ExaminerSurname"/>
        public string ExaminerSurname { get; set; }

        /// <inheritdoc cref="IExaminersTableRowView.ExaminerName"/>
        public string ExaminerName { get; set; }

        /// <inheritdoc cref="IExaminersTableRowView.ExaminerPatronymic"/>
        public string ExaminerPatronymic { get; set; }

        /// <inheritdoc cref="IExaminersTableRowView.ExaminerAverageAssessment"/>
        public double ExaminerAverageAssessment { get; set; }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj is ExaminersTableRowView view && ExaminerSurname == view.ExaminerSurname && ExaminerName == view.ExaminerName && ExaminerPatronymic == view.ExaminerPatronymic && ExaminerAverageAssessment == view.ExaminerAverageAssessment;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            int hashCode = -2129316878;
            hashCode = (hashCode * -1521134295) + ExaminerSurname.GetHashCode();
            hashCode = (hashCode * -1521134295) + ExaminerName.GetHashCode();
            hashCode = (hashCode * -1521134295) + ExaminerPatronymic.GetHashCode();
            hashCode = (hashCode * -1521134295) + ExaminerAverageAssessment.GetHashCode();
            return hashCode;
        }
    }
}