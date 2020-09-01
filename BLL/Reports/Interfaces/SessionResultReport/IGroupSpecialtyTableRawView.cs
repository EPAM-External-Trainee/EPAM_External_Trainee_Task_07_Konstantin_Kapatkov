namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IGroupSpecialtyTableRawView
    {
        string SpecialityName { get; set; }

        double AverageAssessment { get; set; }
    }
}