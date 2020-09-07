using BLL.Reports.Enums;
using BLL.Reports.Structs.ReportData;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IAssessmentDynamicsReport
    {
        AssessmentDynamicsReportData GetReportData();

        AssessmentDynamicsReportData GetReportData(AssessmentDynamicsReportOrderBy orderBy, bool isDesc);
    }
}