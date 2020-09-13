using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataView;
using System.Collections.Generic;

namespace BLL.Reports.Views.GroupSessionResultReport.ReportDataViews
{
    /// <summary>Class describing the view of group session result report</summary>
    public class GroupSessionResultReportView : IGroupSessionResultReportView
    {
        /// <inheritdoc cref="IGroupSessionResultReportView.GroupSessionResultTables"/>
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        /// <inheritdoc cref="IGroupSessionResultReportView.AssessmentDynamicsTable"/>
        public AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}