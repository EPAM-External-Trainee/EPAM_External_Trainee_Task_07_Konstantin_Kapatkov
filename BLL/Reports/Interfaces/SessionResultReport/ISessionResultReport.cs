using BLL.Reports.Views.ReportViews;
using BLL.Reports.Excel.Views.SessionResultReport;
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