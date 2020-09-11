using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataView
{
    public interface IGroupSessionResultReportView
    {
        IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}