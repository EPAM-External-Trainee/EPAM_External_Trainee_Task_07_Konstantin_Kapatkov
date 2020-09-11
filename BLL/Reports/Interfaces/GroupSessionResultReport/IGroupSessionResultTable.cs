using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IGroupSessionResultTable
    {
        IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables();

        IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables(Func<GroupSessionResultTableRawView, object> predicate, bool isDescOrder = false);
    }
}