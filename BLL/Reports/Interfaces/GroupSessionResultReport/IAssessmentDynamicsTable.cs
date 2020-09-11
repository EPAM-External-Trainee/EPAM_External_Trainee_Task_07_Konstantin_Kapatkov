using BLL.Reports.Enums;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IAssessmentDynamicsTable
    {
        AssessmentDynamicsTableView GetAssessmentDynamicsTable();

        AssessmentDynamicsTableView GetAssessmentDynamicsTable(AssessmentDynamicsTableOrderBy orderBy, bool isDesc = false);
    }
}