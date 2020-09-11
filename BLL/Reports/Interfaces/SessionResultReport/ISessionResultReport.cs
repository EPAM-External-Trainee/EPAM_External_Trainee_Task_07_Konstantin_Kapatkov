using BLL.Reports.ExcelViews.ReportViews;
using BLL.Reports.Structs.ExcelTableRawViews.SessionResultReport;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    public interface ISessionResultReport
    {
        SessionResultReportView GetReport(int sessionId);

        SessionResultReportView GetReport(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder);

        SessionResultReportView GetReport(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder);

        SessionResultReportView GetReport(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder);
    }
}