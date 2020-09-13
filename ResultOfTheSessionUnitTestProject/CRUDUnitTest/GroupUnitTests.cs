using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.CRUDUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Group"/> model</summary>
    [TestClass]
    public class GroupUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown", 1)]
        public void CreateGroup_IsTrue_Test(string groupName, int groupSpecialtyId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryCreateAsync(new Group(groupName, groupSpecialtyId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadGroup_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroup().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadGroup_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoGroup().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown", 1)]
        public void UpdateGroup_IsTrue_Test(int id, string groupName, int groupSpecialtyId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryUpdateAsync(new Group(id, groupName, groupSpecialtyId)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown", 1)]
        public void UpdateGroup_IsFalse_Test(int id, string groupName, int groupSpecialtyId)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroup().TryUpdateAsync(new Group(id, groupName, groupSpecialtyId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteGroup_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteGroup_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroup().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllGroups_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroup().TryReadAllAsync().Result);
        }
    }
}