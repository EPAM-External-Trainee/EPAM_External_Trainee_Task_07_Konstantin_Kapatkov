using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Views.ReportViews;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    /// <summary>Interface describing session result report functionality</summary>
    public interface ISessionResultReport
    {
        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="SessionResultReportView"/> report data</returns>
        SessionResultReportView GetReport(int sessionId);

        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="ExaminersTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="SessionResultReportView"/> ordered report data</returns>
        SessionResultReportView GetReport(int sessionId, Func<ExaminersTableRowView, object> predicate, bool isDescOrder);

        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="SpecialtyAssessmetsTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="SessionResultReportView"/> ordered report data</returns>
        SessionResultReportView GetReport(int sessionId, Func<SpecialtyAssessmetsTableRowView, object> predicate, bool isDescOrder);

        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="GroupTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="SessionResultReportView"/> ordered report data</returns>
        SessionResultReportView GetReport(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder);
    }
}