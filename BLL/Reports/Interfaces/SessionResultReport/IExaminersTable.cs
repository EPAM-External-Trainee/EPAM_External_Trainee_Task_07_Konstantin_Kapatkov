using BLL.Reports.Views.SessionResultReport.TableView;
using BLL.Reports.Excel.Views.SessionResultReport;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IExaminersTable
    {
        ExaminersTableView GetExaminersTableData(int sessionId);

        ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder);
    }
}