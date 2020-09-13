namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews
{
    /// <summary>Interface describing the row view of the group specialty table</summary>
    public interface IGroupSpecialtyTableRowView
    {
        /// <summary>Speciality name</summary>
        string SpecialityName { get; set; }

        /// <summary>Speciality average assessment</summary>
        double SpecialityAverageAssessment { get; set; }
    }
}