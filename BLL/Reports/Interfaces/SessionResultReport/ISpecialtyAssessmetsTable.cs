using BLL.Reports.Views.SessionResultReport.TableView;
using BLL.Reports.Excel.Views.SessionResultReport;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISpecialtyAssessmetsTable
    {
        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId);

        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder);
    }
}