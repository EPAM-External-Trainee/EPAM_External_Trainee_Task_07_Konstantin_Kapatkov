using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataView;
using BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport
{
    public class GroupSessionResultReportView : IGroupSessionResultReportView
    {
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        public AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}