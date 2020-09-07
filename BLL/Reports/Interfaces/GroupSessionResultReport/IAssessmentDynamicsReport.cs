using BLL.Reports.Enums;
using BLL.Reports.Structs.ReportData;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IAssessmentDynamicsReport
    {
        DynamicChangesInAverageMarkReportData GetReportData();

        DynamicChangesInAverageMarkReportData GetReportData(AssessmentDynamicsReportOrderBy orderBy, bool isDesc);
    }
}