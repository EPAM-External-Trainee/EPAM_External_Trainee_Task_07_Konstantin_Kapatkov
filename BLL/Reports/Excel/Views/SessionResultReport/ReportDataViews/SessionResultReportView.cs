using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews;
using BLL.Reports.Views.SessionResultReport.TableView;
using System.Collections.Generic;

namespace BLL.Reports.Views.ReportViews
{
    /// <summary>Class describing the view of session result report</summary>
    public class SessionResultReportView : ISessionResultReportView
    {
        /// <inheritdoc cref="ISessionResultReportView.GroupTables"/>
        public IEnumerable<GroupTableView> GroupTables { get; set; }

        /// <inheritdoc cref="ISessionResultReportView.SpecialtyAssessmetsTable"/>
        public SpecialtyAssessmetsTableView SpecialtyAssessmetsTable { get; set; }

        /// <inheritdoc cref="ISessionResultReportView.ExaminersTable"/>
        public ExaminersTableView ExaminersTable { get; set; }
    }
}