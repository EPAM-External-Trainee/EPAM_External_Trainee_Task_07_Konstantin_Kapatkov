using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.SessionResultReport
{
    public struct SpecialtyAssessmetsTableRawView : ISpecialtyAssessmetsTableRawView
    {
        public SpecialtyAssessmetsTableRawView(string specialityName, double averageAssessment)
        {
            SpecialityName = specialityName;
            AverageAssessment = averageAssessment;
        }

        public string SpecialityName { get; set; }

        public double AverageAssessment { get; set; }

        public override bool Equals(object obj) => obj is SpecialtyAssessmetsTableRawView view && SpecialityName == view.SpecialityName && AverageAssessment == view.AverageAssessment;

        public override int GetHashCode()
        {
            int hashCode = 1942220009;
            hashCode = (hashCode * -1521134295) + SpecialityName.GetHashCode();
            hashCode = (hashCode * -1521134295) + AverageAssessment.GetHashCode();
            return hashCode;
        }
    }
}