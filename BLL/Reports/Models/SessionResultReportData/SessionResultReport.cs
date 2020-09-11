using BLL.Reports.ExcelViews.ReportViews;
using BLL.Reports.Models.SessionResultReportData;
using BLL.Reports.Models.SessionResultReportData.Tables;

namespace BLL.Reports.Models
{
    public class SessionResultReport  /*ISessionResultReport*/
    {
        public string ConnectionString { get; set; } = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        public SessionResultReport(string connectionString) => ConnectionString = connectionString;

        public SessionResultReportView GetReport(int sessionId)
        {
            ExaminersTable examinersTable = new ExaminersTable(ConnectionString);
            GroupTable groupTable = new GroupTable(ConnectionString);
            SpecialtyAssessmetsTable specialtyAssessmetsTable = new SpecialtyAssessmetsTable(ConnectionString);

            return new SessionResultReportView
            {
                GroupTables = groupTable.GetGroupTableData(sessionId),
                SpecialtyAssessmetsTable = specialtyAssessmetsTable.GetSpecialtyAssessmetsTableData(sessionId),
                ExaminersTable = examinersTable.GetExaminersTableData(sessionId)
            };
        }
    }
}