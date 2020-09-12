using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.SessionResultReport
{
    public struct ExaminersTableRawView : IExaminersTableRawView
    {
        public ExaminersTableRawView(string examinerSurname, string examinerName, string examinerPatronymic, double averageAssessment)
        {
            ExaminerSurname = examinerSurname;
            ExaminerName = examinerName;
            ExaminerPatronymic = examinerPatronymic;
            ExaminerAverageAssessment = averageAssessment;
        }

        public string ExaminerSurname { get; set; }

        public string ExaminerName { get; set; }

        public string ExaminerPatronymic { get; set; }

        public double ExaminerAverageAssessment { get; set; }

        public override bool Equals(object obj) => obj is ExaminersTableRawView view && ExaminerSurname == view.ExaminerSurname && ExaminerName == view.ExaminerName && ExaminerPatronymic == view.ExaminerPatronymic && ExaminerAverageAssessment == view.ExaminerAverageAssessment;

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