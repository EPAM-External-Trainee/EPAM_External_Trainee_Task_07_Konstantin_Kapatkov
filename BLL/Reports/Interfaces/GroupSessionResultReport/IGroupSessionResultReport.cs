using BLL.Reports.Enums;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Views.GroupSessionResultReport.ReportDataViews;
using System;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    public interface IGroupSessionResultReport
    {
        GroupSessionResultReportView GetReport();

        GroupSessionResultReportView GetReport(Func<GroupSessionResultTableRawView, object> predicate, bool isDescOrder);

        GroupSessionResultReportView GetReport(AssessmentDynamicsTableOrderBy orderBy, bool isDescOrder);
    }
}