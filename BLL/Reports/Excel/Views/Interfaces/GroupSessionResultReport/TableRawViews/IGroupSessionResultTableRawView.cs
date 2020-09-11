namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IGroupSessionResultTableRawView
    {
        string GroupName { get; set; }

        double MaxAssessment { get; set; }

        double MinAssessment { get; set; }

        double AvgAssessment { get; set; }
    }
}