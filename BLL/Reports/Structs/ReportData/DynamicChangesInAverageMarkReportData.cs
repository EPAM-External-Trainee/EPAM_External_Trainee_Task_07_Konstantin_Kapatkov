using BLL.Reports.Structs.ExcelTableRawViews.DynamicChangesInAverageMark;
using System.Collections.Generic;

namespace BLL.Reports.Structs.ReportData
{
    public class DynamicChangesInAverageMarkReportData
    {
        public DynamicChangesInAverageMarkReportData()
        {
        }

        public DynamicChangesInAverageMarkReportData(IEnumerable<TableRowView> tableRowViews, IEnumerable<string> years)
        {
            TableRowViews = tableRowViews;
            Years = years;
        }

        public IEnumerable<TableRowView> TableRowViews { get; set; }

        public IEnumerable<string> Years { get; set; }
    }
}