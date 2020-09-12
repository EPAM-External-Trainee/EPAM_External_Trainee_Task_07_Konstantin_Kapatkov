using DAL.DAO.Models;

namespace ResultOfTheSessionUnitTestProject.CRUDUnitTest
{
    public abstract class CRUDUnitTestData
    {
        protected DaoFactory DaoFactory { get; } = DaoFactory.GetInstance(@"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;");
    }
}