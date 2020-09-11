using BLL.Reports.ExcelViews.SessionResultReport.TableView;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISpecialtyAssessmetsTable
    {
        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId);

        SpecialtyAssessmetsTableView GetSpecialtyAssessmetsTableData(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder);
    }
}