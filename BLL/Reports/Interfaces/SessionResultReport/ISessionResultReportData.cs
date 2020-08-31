using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISessionResultReportData
    {
        IEnumerable<GroupTableRawView> GroupTableRawViews { get; set; }

        string SessionInfo { get; set; }

        string GroupName { get; set; }

        IEnumerable<GroupSpecialtyTableRawView> GroupSpecialtyTableRawViews { get; set; }

        IEnumerable<ExaminersTableRawView> ExaminersTableRawViews { get; set; }
    }
}