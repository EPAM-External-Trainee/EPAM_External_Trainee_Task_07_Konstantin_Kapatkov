using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IExaminersTable
    {
        ExaminersTableView GetExaminersTableData(int sessionId);

        ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder);
    }
}