using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    /// <summary>Interface describing examiners table functionality</summary>
    public interface IExaminersTable
    {
        /// <summary>Getting examiners table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="ExaminersTableView"/> table data</returns>
        ExaminersTableView GetExaminersTableData(int sessionId);

        /// <summary>Getting examiners table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="ExaminersTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="ExaminersTableView"/> ordered table data</returns>
        ExaminersTableView GetExaminersTableData(int sessionId, Func<ExaminersTableRowView, object> predicate, bool isDescOrder);
    }
}