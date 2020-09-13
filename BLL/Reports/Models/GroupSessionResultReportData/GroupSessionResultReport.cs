using BLL.Reports.Enums;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRawViews;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Views.GroupSessionResultReport.ReportDataViews;
using System;

namespace BLL.Reports.Models.ReportData
{
    /// <summary>Class describing group session result report functionality</summary>
    public class GroupSessionResultReport : IGroupSessionResultReport
    {
        /// <summary>Group session result table</summary>
        private IGroupSessionResultTable GroupSessionResultTable { get; }

        /// <summary>Assessment dynamics table</summary>
        private IAssessmentDynamicsTable AssessmentDynamicsTable { get; }

        /// <summary>Creating an instance of <see cref="GroupSessionResultReport"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public GroupSessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            GroupSessionResultTable = new GroupSessionResultTable(connectionString);
            AssessmentDynamicsTable = new AssessmentDynamicsTable(connectionString);
        }

        /// <inheritdoc cref="IGroupSessionResultReport.GetReport"/>
        public GroupSessionResultReportView GetReport()
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(),
                AssessmentDynamicsTable = AssessmentDynamicsTable.GetAssessmentDynamicsTable()
            };
        }

        /// <inheritdoc cref="IGroupSessionResultReport.GetReport(Func{GroupSessionResultTableRowView, object}, bool)/>
        public GroupSessionResultReportView GetReport(Func<GroupSessionResultTableRowView, object> predicate, bool isDescOrder = false)
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(predicate, isDescOrder),
                AssessmentDynamicsTable = AssessmentDynamicsTable.GetAssessmentDynamicsTable()
            };
        }

        /// <inheritdoc cref="IGroupSessionResultReport.GetReport(AssessmentDynamicsTableOrderBy, bool)/>
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