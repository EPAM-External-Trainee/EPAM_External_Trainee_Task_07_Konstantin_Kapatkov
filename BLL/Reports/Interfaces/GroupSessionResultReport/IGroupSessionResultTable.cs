using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport;
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