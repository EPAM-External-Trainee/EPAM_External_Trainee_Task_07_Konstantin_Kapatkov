using BLL.Reports.Views.ReportViews;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Models.SessionResultReportData;
using BLL.Reports.Models.SessionResultReportData.Tables;
using BLL.Reports.Excel.Views.SessionResultReport;
using System;

namespace BLL.Reports.Models
{
    public class SessionResultReport : ISessionResultReport
    {
        public SessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            ExaminersTable = new ExaminersTable(connectionString);
            GroupTable = new GroupTable(connectionString);
            SpecialtyAssessmetsTable = new SpecialtyAssessmetsTable(connectionString);
        }

        public IExaminersTable ExaminersTable { get; set; }

        public IGroupTable GroupTable { get; set; }

        public ISpecialtyAssessmetsTable SpecialtyAssessmetsTable { get; set; }

        public SessionResultReportView GetReport(int sessionId)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId)
            };
        }

        public SessionResultReportView GetReport(int sessionId, Func<ExaminersTableRawView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId, predicate, isDescOrder)
            };
        }

        public SessionResultReportView GetReport(int sessionId, Func<SpecialtyAssessmetsTableRawView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = GroupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = SpecialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId, predicate, isDescOrder),
                ExaminersTable = ExaminersTable.GetExaminersTableData(sessionId)
            };
        }

        public SessionResultReportView GetReport(int sessionId, Func<GroupTableRawView, object> predicate, bool isDescOrder)
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