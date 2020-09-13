using BLL.Reports.Views.SessionResultReport.TableView;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews
{
    /// <summary>Interface describing the view of session result report</summary>
    public interface ISessionResultReportView
    {
        /// <summary><see cref="GroupTableView"/> objects as group tables</summary>
        IEnumerable<GroupTableView> GroupTables { get; set; }

        /// <summary><see cref="SpecialtyAssessmetsTableView"/> object as specialty assessmets table</summary>
        SpecialtyAssessmetsTableView SpecialtyAssessmetsTable { get; set; }

        /// <summary><see cref="ExaminersTableView"/> object as examiners table</summary>
        ExaminersTableView ExaminersTable { get; set; }
    }
}