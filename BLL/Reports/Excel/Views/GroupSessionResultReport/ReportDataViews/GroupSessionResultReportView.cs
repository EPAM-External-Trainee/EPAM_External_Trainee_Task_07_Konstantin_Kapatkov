using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataView;
using System.Collections.Generic;

namespace BLL.Reports.Views.GroupSessionResultReport.ReportDataViews
{
    public class GroupSessionResultReportView : IGroupSessionResultReportView
    {
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        public AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}