using System.Collections.Generic;

namespace BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark
{
    public struct TableRowView
    {
        public TableRowView(string subjectName, List<double> assessments)
        {
            SubjectName = subjectName;
            AvgAssessments = assessments;
        }

        public string SubjectName { get; set; }

        public List<double> AvgAssessments { get; set; }
    }
}