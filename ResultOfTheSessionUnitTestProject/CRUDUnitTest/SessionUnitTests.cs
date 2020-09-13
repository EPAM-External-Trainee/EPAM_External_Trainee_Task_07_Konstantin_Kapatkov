using DAL.ORM.Models.SessionInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Session"/> model</summary>
    [TestClass]
    public class SessionUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown", "2008/2009")]
        public void CreateSession_IsTrue_Test(string name, string academicYear)
        {
            Assert.IsTrue(DaoFactory.GetDaoSession().TryCreateAsync(new Session(name, academicYear)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadSession_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoSession().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadSession_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoSession().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown", "2011/2012")]
        public void UpdateSession_IsTrue_Test(int id, string name, string academicYear)
        {
            Assert.IsTrue(DaoFactory.GetDaoSession().TryUpdateAsync(new Session(id, name, academicYear)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown", "2011/2012")]
        public void UpdateSession_IsFalse_Test(int id, string name, string academicYear)
        {
            Assert.IsFalse(DaoFactory.GetDaoSession().TryUpdateAsync(new Session(id, name, academicYear)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteSession_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoSession().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteSession_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoSession().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllSessions_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoSession().TryReadAllAsync().Result);
        }
    }
}