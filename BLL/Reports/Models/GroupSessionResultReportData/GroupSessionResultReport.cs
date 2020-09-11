using BLL.Reports.ExcelViews.ExcelTableView.GroupSessionResultReport;

namespace BLL.Reports.Models.ReportData
{
    public class GroupSessionResultReport /*: IGroupSessionResultReportData*/
    {
        public GroupSessionResultReport(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; } = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        public GroupSessionResultReportView GetReport()
        {
            GroupSessionResultTable groupSessionResultTable = new GroupSessionResultTable(ConnectionString);
            AssessmentDynamicsTable assessmentDynamicsTable = new AssessmentDynamicsTable(ConnectionString);

            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = groupSessionResultTable.GetGroupSessionResultTables(),
                AssessmentDynamicsTable = assessmentDynamicsTable.GetAssessmentDynamicsTable()
            };
        }
    }
}