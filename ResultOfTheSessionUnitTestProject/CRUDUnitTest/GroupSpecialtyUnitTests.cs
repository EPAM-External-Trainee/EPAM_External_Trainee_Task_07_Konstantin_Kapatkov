using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    /// <summary>Class describes testing CRUD functionality for <see cref="GroupSpecialty"/> model</summary>
    [TestClass]
    public class GroupSpecialtyUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown")]
        public void CreateGroupSpecialty_IsTrue_Test(string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroupSpecialty().TryCreateAsync(new GroupSpecialty(name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadGroupSpecialty_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroupSpecialty().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadGroupSpecialty_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoGroupSpecialty().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown")]
        public void CreateGroupSpecialty_IsTrue_Test(int id, string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroupSpecialty().TryUpdateAsync(new GroupSpecialty(id, name)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown")]
        public void CreateGroupSpecialty_IsFalse_Test(int id, string name)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroupSpecialty().TryUpdateAsync(new GroupSpecialty(id, name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteGroupSpecialty_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroupSpecialty().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteGroupSpecialty_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroupSpecialty().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllGroupSpecialty_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroupSpecialty().TryReadAllAsync().Result);
        }
    }
}