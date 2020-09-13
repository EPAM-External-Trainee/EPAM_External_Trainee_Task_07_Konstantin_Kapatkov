using BLL.Reports.Interfaces.GroupSessionResultReport;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews
{
    /// <summary>Struct describing the row view of the assessment dynamics table</summary>
    public struct AssessmentDynamicsTableRowView : IAssessmentDynamicsTableRowView
    {
        /// <summary>Сreating an instance of <see cref="AssessmentDynamicsTableRowView"/> via subject name and assessments</summary>
        /// <param name="subjectName">Subject name</param>
        /// <param name="assessments">Subject assessments</param>
        public AssessmentDynamicsTableRowView(string subjectName, IEnumerable<double> assessments)
        {
            SubjectName = subjectName;
            AvgAssessments = assessments;
        }

        /// <inheritdoc cref="IAssessmentDynamicsTableRowView.SubjectName"/>
        public string SubjectName { get; set; }

        /// <inheritdoc cref="IAssessmentDynamicsTableRowView.AvgAssessments"/>
        public IEnumerable<double> AvgAssessments { get; set; }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj is AssessmentDynamicsTableRowView view && SubjectName == view.SubjectName && AvgAssessments.SequenceEqual(view.AvgAssessments);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            int hashCode = 625787162;
            hashCode = (hashCode * -1521134295) + SubjectName.GetHashCode();
            hashCode = (hashCode * -1521134295) + AvgAssessments.GetHashCode();
            return hashCode;
        }
    }
}