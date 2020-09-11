using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using System.Collections.Generic;

namespace BLL.Reports.ExcelViews.ReportViews
{
    public class SessionResultReportView
    {
        public IEnumerable<GroupTableView> GroupTables { get; set; }

        public SpecialtyAssessmetsTableView SpecialtyAssessmetsTable { get; set; }

        public ExaminersTableView ExaminersTable { get; set; }
    }
}