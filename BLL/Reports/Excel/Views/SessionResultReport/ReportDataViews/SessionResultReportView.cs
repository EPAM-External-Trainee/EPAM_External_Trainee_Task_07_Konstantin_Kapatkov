using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews;
using BLL.Reports.Views.SessionResultReport.TableView;
using System.Collections.Generic;

namespace BLL.Reports.Views.ReportViews
{
    public class SessionResultReportView : ISessionResultReportView
    {
        public IEnumerable<GroupTableView> GroupTables { get; set; }

        public SpecialtyAssessmetsTableView SpecialtyAssessmetsTable { get; set; }

        public ExaminersTableView ExaminersTable { get; set; }
    }
}