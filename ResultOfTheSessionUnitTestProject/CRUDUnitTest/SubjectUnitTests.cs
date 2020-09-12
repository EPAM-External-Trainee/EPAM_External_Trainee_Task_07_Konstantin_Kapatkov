using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class SubjectUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown")]
        public void CreateSubject_IsTrue_Test(string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoSubject().TryCreateAsync(new Subject(name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadSubject_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoSubject().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadSubject_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoSubject().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown")]
        public void UpdateSubject_IsTrue_Test(int id, string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoSubject().TryUpdateAsync(new Subject(id, name)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown")]
        public void UpdateSubject_IsFalse_Test(int id, string name)
        {
            Assert.IsFalse(DaoFactory.GetDaoSubject().TryUpdateAsync(new Subject(id, name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteSubject_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoSubject().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteSubject_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoSubject().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllSubjects_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoSubject().TryReadAllAsync().Result);
        }
    }
}