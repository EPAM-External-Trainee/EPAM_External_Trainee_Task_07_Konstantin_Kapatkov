using DAL.DB.DBDeployment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.DBDeploymentTest
{
    [TestClass]
    public class DBDeploymentTests
    {
        [TestMethod]
        public void DBDeploy_IsTrue_Test()
        {
            Assert.IsTrue(DatabaseDeployment.TryExpandTheDatabaseAsync().Result);
        }
    }
}