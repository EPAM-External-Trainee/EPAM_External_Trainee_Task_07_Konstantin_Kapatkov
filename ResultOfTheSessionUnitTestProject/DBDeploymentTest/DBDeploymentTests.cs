using DAL.DB.DBDeployment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.DBDeploymentTest
{
    /// <summary>Class describes functionality for testing <see cref="DatabaseDeployment"/> class</summary>
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