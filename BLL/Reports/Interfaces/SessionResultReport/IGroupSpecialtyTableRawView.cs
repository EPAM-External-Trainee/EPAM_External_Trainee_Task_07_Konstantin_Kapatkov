namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISpecialtyAssessmetsTableRawView
    {
        string SpecialityName { get; set; }

        double AverageAssessment { get; set; }
    }
}