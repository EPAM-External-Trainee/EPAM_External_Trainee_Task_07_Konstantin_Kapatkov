namespace ResultOfTheSessionUnitTestProject.ReportsUnitTest
{
    /// <summary>Class describes common data for testing reports classes</summary>
    public abstract class ReportsUnitTestData
    {
        /// <summary>SQL Server connection string</summary>
        protected const string ConnectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        /// <summary>Path to session result report excel file</summary>
        protected const string PathToSessionResultReportExcelFile = @"..\..\..\ResultOfTheSessionUnitTestProject\ReportsUnitTest\Resources\SessionResultReport.xlsx";

        /// <summary>Path to group session result report excel file</summary>
        protected const string PathToGroupSessionResultReportExcelFile = @"..\..\..\ResultOfTheSessionUnitTestProject\ReportsUnitTest\Resources\GroupSessionResultReport.xlsx";
    }
}