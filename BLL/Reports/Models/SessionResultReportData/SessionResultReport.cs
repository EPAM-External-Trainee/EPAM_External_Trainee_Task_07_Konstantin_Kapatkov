using BLL.Reports.Excel.Views.SessionResultReport;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Models.SessionResultReportData;
using BLL.Reports.Models.SessionResultReportData.Tables;
using BLL.Reports.Views.ReportViews;
using System;

namespace BLL.Reports.Models
{
    /// <summary>Class describing session result report functionality</summary>
    public class SessionResultReport : ISessionResultReport
    {
        /// <summary>Examiners table</summary>
        private IExaminersTable ExaminersTable { get; }

        /// <summary>Group table</summary>
        private IGroupTable GroupTable { get; }

        /// <summary>Specialty assessmets table</summary>
        private ISpecialtyAssessmetsTable SpecialtyAssessmetsTable { get; }

        /// <summary>Creating an instance of <see cref="SessionResultReport"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public SessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            ExaminersTable = new ExaminersTable(connectionString);
            GroupTable = new GroupTable(connectionString);
            SpecialtyAssessmetsTable = new SpecialtyAssessmetsTable(connectionString);
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int)"/>
        public SessionResultReportView GetReport(int sessionId)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId)
            };
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int, Func{ExaminersTableRowView, object}, bool)"/>
        public SessionResultReportView GetReport(int sessionId, Func<ExaminersTableRowView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId, predicate, isDescOrder)
            };
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int, Func{SpecialtyAssessmetsTableRowView, object}, bool)"/>
        public SessionResultReportView GetReport(int sessionId, Func<SpecialtyAssessmetsTableRowView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId, predicate, isDescOrder),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId)
            };
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int, Func{GroupTableRowView, object}, bool)"/>
        public SessionResultReportView GetReport(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId, predicate, isDescOrder),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId)
            };
        }
    }
}