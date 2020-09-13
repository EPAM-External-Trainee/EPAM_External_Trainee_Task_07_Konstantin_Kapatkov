using BLL.Reports.Enums;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    /// <summary>Interface describing assessment dynamics table functionality</summary>
    public interface IAssessmentDynamicsTable
    {
        /// <summary>Getting assessment dynamics table data</summary>
        /// <returns><see cref="AssessmentDynamicsTableView"/> table data</returns>
        AssessmentDynamicsTableView GetAssessmentDynamicsTable();

        /// <summary>Getting assessment dynamics table data</summary>
        /// <param name="orderBy"><see cref="AssessmentDynamicsTableRowView"/> column to sort the selection by</param>
        /// <param name="isDesc">Is descending order</param>
        /// <returns><see cref="AssessmentDynamicsTableView"/>ordered table data</returns>
        AssessmentDynamicsTableView GetAssessmentDynamicsTable(AssessmentDynamicsTableOrderBy orderBy, bool isDesc = false);
    }
}