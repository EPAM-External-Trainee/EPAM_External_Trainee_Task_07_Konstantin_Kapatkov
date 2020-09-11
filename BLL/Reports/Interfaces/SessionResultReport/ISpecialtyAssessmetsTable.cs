using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Views.SessionResultReport.TableView;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISpecialtyAssessmetsTable
    {
        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId);

        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder);
    }
}