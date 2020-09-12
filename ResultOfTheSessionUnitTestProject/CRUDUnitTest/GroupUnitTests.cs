using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class GroupUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown", 1)]
        public void CreateGroup_IsTrue_Test(string name, int specialtyId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryCreateAsync(new Group(name, specialtyId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadGroup_IsNotNull_Test(int groupId)
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroup().TryReadAsync(groupId).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadGroup_IsNull_Test(int groupId)
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroup().TryReadAsync(groupId).Result);
        }

        [TestMethod]
        [DataRow(1, "UnknownUpdate", 1)]
        public void UpdateGroup_IsTrue_Test(int groupId, string name, int specialtyId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryUpdateAsync(new Group(groupId, name, specialtyId)).Result);
        }

        [TestMethod]
        [DataRow(10, "UnknownUpdate", 1)]
        public void UpdateGroup_IsFalse_Test(int groupId, string name, int specialtyId)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroup().TryUpdateAsync(new Group(groupId, name, specialtyId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteGroup_IsTrue_Test(int groupId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGroup().TryDeleteAsync(groupId).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteGroup_IsFalse_Test(int groupId)
        {
            Assert.IsFalse(DaoFactory.GetDaoGroup().TryDeleteAsync(groupId).Result);
        }

        [TestMethod]
        public void ReadAllGroups_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoGroup().TryReadAllAsync().Result);
        }
    }
}