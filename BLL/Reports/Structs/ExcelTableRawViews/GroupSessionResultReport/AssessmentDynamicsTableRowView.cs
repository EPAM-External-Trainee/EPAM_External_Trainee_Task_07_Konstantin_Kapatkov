using BLL.Reports.Interfaces.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark
{
    public struct AssessmentDynamicsTableRowView : IAssessmentDynamicsTableRowView
    {
        public AssessmentDynamicsTableRowView(string subjectName, List<double> assessments)
        {
            SubjectName = subjectName;
            AvgAssessments = assessments;
        }

        public string SubjectName { get; set; }

        public IEnumerable<double> AvgAssessments { get; set; }
    }
}