using BLL.Reports.Enums;
using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
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