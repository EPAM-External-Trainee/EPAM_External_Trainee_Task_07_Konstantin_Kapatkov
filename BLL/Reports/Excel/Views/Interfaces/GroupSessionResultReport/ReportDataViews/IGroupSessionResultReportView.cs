using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataView
{
    public interface IGroupSessionResultReportView
    {
        IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}