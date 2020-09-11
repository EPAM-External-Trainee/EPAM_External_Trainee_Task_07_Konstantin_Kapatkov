using BLL.Reports.Views.SessionResultReport.TableView;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews
{
    public interface ISessionResultReportView
    {
        IEnumerable<GroupTableView> GroupTables { get; set; }

        SpecialtyAssessmetsTableView SpecialtyAssessmetsTable { get; set; }

        ExaminersTableView ExaminersTable { get; set; }
    }
}