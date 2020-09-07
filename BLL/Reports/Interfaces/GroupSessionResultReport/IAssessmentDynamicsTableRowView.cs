using System.Collections.Generic;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IAssessmentDynamicsTableRowView
    {
        string SubjectName { get; set; }

        IEnumerable<double> AvgAssessments { get; set; }
    }
}