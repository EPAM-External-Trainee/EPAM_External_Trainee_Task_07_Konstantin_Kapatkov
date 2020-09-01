using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISessionResultReportData
    {
        Dictionary<string, List<GroupTableRawView>> GroupTableRawViews { get; set; }

        string SessionInfo { get; set; }

        IEnumerable<GroupSpecialtyTableRawView> GroupSpecialtyTableRawViews { get; set; }

        IEnumerable<ExaminersTableRawView> ExaminersTableRawViews { get; set; }
    }
}