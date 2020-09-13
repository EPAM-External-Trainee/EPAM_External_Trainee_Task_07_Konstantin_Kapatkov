using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews;

namespace BLL.Reports.Excel.Views.SessionResultReport
{
    /// <summary>Struct describing the row view of the group specialty table</summary>
    public struct SpecialtyAssessmetsTableRowView : IGroupSpecialtyTableRowView
    {
        /// <summary>Creating an instance of <see cref="SpecialtyAssessmetsTableRowView"/> via speciality name and average assessment</summary>
        /// <param name="specialityName">Speciality name</param>
        /// <param name="averageAssessment">Average assessment</param>
        public SpecialtyAssessmetsTableRowView(string specialityName, double averageAssessment)
        {
            SpecialityName = specialityName;
            SpecialityAverageAssessment = averageAssessment;
        }

        /// <inheritdoc cref="IGroupSpecialtyTableRowView.SpecialityName"/>
        public string SpecialityName { get; set; }

        /// <inheritdoc cref="IGroupSpecialtyTableRowView.SpecialityAverageAssessment"/>
        public double SpecialityAverageAssessment { get; set; }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj is SpecialtyAssessmetsTableRowView view && SpecialityName == view.SpecialityName && SpecialityAverageAssessment == view.SpecialityAverageAssessment;


        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            int hashCode = 1942220009;
            hashCode = (hashCode * -1521134295) + SpecialityName.GetHashCode();
            hashCode = (hashCode * -1521134295) + SpecialityAverageAssessment.GetHashCode();
            return hashCode;
        }
    }
}