using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface IExaminersTable
    {
        ExaminersTableView GetExaminersTableData(int sessionId);

        ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder);
    }
}