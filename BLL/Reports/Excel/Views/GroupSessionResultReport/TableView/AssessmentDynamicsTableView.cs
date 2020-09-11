using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport
{
    public class AssessmentDynamicsTableView
    {
        public AssessmentDynamicsTableView()
        {
        }

        public AssessmentDynamicsTableView(IEnumerable<AssessmentDynamicsTableRowView> tableRowViews, IEnumerable<string> academicYears)
        {
            AcademicYears = academicYears;
            TableRowViews = tableRowViews;
        }

        public readonly string[] Headers = new string[] { "Subject", "Assessment" };

        public IEnumerable<string> AcademicYears { get; set; }

        public IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }
    }
}