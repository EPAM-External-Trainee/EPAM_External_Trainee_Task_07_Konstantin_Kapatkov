using BLL.Reports.Structs.ExcelTableView.GroupSessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport
{
    public class GroupSessionResultReportView
    {
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        public AssessmentDynamicsTableView AssessmentDynamicsTable { get; set; }
    }
}