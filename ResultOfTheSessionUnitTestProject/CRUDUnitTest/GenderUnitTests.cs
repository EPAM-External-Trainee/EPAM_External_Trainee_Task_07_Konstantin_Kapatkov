using DAL.DAO.Models;
using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class GenderUnitTests
    {
        private DaoFactory daoFactory = DaoFactory.GetInstance(@"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;");

        [TestMethod]
        [DataRow("Unknown")]
        public void CreateGender_IsTrue_Test(string newGenderName)
        {
            Assert.IsTrue(daoFactory.GetDaoGender().TryCreateAsync(new Gender(newGenderName)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadGender_IsNotNull_Test(int genderId)
        {
            Assert.IsNotNull(daoFactory.GetDaoGender().TryReadAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(20)]
        public void ReadGender_IsNull_Test(int genderId)
        {
            Assert.IsNull(daoFactory.GetDaoGender().TryReadAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(3, "UnknownAfterUpdate")]
        public void UpdateGender_IsTrue_Test(int genderId, string genderName)
        {
            Assert.IsTrue(daoFactory.GetDaoGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [TestMethod]
        [DataRow(23, "UnknownAfterUpdate")]
        public void UpdateGender_IsFalse_Test(int genderId, string genderName)
        {
            Assert.IsFalse(daoFactory.GetDaoGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [TestMethod]
        [DataRow(3)]
        public void DeleteGender_IsTrue_Test(int genderId)
        {
            Assert.IsTrue(daoFactory.GetDaoGender().TryDeleteAsync(genderId).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteGender_IsFalse_Test(int genderId)
        {
            Assert.IsFalse(daoFactory.GetDaoGender().TryDeleteAsync(genderId).Result);
        }
    }
}