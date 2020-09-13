using System.Collections.Generic;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    /// <summary>Interface describing the row view of the assessment dynamics table</summary>
    public interface IAssessmentDynamicsTableRowView
    {
        /// <summary>Subject name</summary>
        string SubjectName { get; set; }

        /// <summary>The average assessments of the subject for years</summary>
        IEnumerable<double> AvgAssessments { get; set; }
    }
}