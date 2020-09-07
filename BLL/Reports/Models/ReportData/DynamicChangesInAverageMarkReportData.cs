using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using System.Collections.Generic;

namespace BLL.Reports.Structs.ReportData
{
    public class DynamicChangesInAverageMarkReportData : IDynamicChangesInAverageMarkReportData
    {
        public DynamicChangesInAverageMarkReportData()
        {
        }

        public DynamicChangesInAverageMarkReportData(IEnumerable<AssessmentDynamicsTableRowView> tableRowViews, IEnumerable<string> years)
        {
            TableRowViews = tableRowViews;
            AcademicYears = years;
        }

        public IEnumerable<AssessmentDynamicsTableRowView> TableRowViews { get; set; }

        public IEnumerable<string> AcademicYears { get; set; }
    }
}