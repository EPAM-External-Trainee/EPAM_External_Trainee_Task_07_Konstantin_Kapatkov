using DAL.DAO.Models;
using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class GenderUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown")]
        public void CreateGender_IsTrue_Test(string newGenderName)
        {
            Assert.IsTrue(DaoFactory.GetDaoGender().TryCreateAsync(new Gender(newGenderName)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadGender_IsNotNull_Test(int genderId)
        {
            Assert.IsNotNull(DaoFactory.GetDaoGender().TryReadAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(20)]
        public void ReadGender_IsNull_Test(int genderId)
        {
            Assert.IsNull(DaoFactory.GetDaoGender().TryReadAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(3, "UnknownAfterUpdate")]
        public void UpdateGender_IsTrue_Test(int genderId, string genderName)
        {
            Assert.IsTrue(DaoFactory.GetDaoGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [TestMethod]
        [DataRow(23, "UnknownAfterUpdate")]
        public void UpdateGender_IsFalse_Test(int genderId, string genderName)
        {
            Assert.IsFalse(DaoFactory.GetDaoGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [TestMethod]
        [DataRow(3)]
        public void DeleteGender_IsTrue_Test(int genderId)
        {
            Assert.IsTrue(DaoFactory.GetDaoGender().TryDeleteAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteGender_IsFalse_Test(int genderId)
        {
            Assert.IsFalse(DaoFactory.GetDaoGender().TryDeleteAsync(genderId).Result);
        }
    }
}