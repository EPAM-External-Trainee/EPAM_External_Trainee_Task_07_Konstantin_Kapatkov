using BLL.Reports.Views.SessionResultReport.TableView;
using BLL.Reports.Excel.Views.SessionResultReport;
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