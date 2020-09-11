using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IGroupSessionResultReportData
    {
        IEnumerable<GroupSessionResultTableRawView> GroupSessionResultReportRowViews { get; set; }

        IEnumerable<string> SessionNames { get; set; }

        IEnumerable<string> AcademicYears { get; set; }

        string[] HeadersGroupSessionResultTable { get; }
    }
}