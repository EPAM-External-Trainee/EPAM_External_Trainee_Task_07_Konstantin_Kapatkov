using BLL.Reports.Interfaces.GroupSessionResultReport;
using System.Collections.Generic;
using System.Linq;

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

        public override bool Equals(object obj) => obj is AssessmentDynamicsTableRowView view && SubjectName == view.SubjectName && AvgAssessments.SequenceEqual(view.AvgAssessments);

        public override int GetHashCode()
        {
            int hashCode = 625787162;
            hashCode = (hashCode * -1521134295) + SubjectName.GetHashCode();
            hashCode = (hashCode * -1521134295) + AvgAssessments.GetHashCode();
            return hashCode;
        }
    }
}