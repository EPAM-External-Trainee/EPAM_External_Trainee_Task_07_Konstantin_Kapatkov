using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    /// <summary>Interface describing specialty assessmets table functionality</summary>
    public interface ISpecialtyAssessmetsTable
    {
        /// <summary>Getting specialty assessmets table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="SpecialtyAssessmetsTableView"/> table data</returns>
        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId);

        /// <summary>Getting specialty assessmets table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="SpecialtyAssessmetsTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="SpecialtyAssessmetsTableView"/> ordered table data</returns>
        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRowView, object> predicate, bool isDescOrder);
    }
}