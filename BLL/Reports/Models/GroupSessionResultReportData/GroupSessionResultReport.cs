using BLL.Reports.Enums;
using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Structs.ExcelTableRawViews.GroupSessionResultReport;
using System;

namespace BLL.Reports.Models.ReportData
{
    public class GroupSessionResultReport : IGroupSessionResultReport
    {
        public GroupSessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            GroupSessionResultTable = new GroupSessionResultTable(connectionString);
            AssessmentDynamicsTable = new AssessmentDynamicsTable(connectionString);
        }

        public GroupSessionResultTable GroupSessionResultTable { get; set; }

        public AssessmentDynamicsTable AssessmentDynamicsTable { get; set; }

        public GroupSessionResultReportView GetReport()
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(),
                AssessmentDynamicsTable = AssessmentDynamicsTable.GetAssessmentDynamicsTable()
            };
        }

        public GroupSessionResultReportView GetReport(Func<GroupSessionResultTableRawView, object> predicate, bool isDescOrder)
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(predicate, isDescOrder),
                AssessmentDynamicsTable = AssessmentDynamicsTable.GetAssessmentDynamicsTable()
            };
        }

        public GroupSessionResultReportView GetReport(AssessmentDynamicsTableOrderBy orderBy, bool isDescOrder)
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(),
                AssessmentDynamicsTable = AssessmentDynamicsTable.GetAssessmentDynamicsTable(orderBy, isDescOrder)
            };
        }
    }
}