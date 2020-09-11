using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IGroupTable
    {
        IEnumerable<GroupTableView> GetGroupTableData(int sessionId);

        IEnumerable<GroupTableView> GetGroupTableData(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder);
    }
}