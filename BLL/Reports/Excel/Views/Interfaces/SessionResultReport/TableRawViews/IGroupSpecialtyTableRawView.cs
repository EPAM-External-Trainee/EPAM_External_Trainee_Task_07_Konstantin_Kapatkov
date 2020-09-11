namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRawViews
{
    public interface ISpecialtyAssessmetsTableRawView
    {
        string SpecialityName { get; set; }

        double AverageAssessment { get; set; }
    }
}