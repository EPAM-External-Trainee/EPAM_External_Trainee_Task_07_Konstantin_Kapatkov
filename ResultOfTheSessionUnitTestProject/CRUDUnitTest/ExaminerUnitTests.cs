using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class ExaminerUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown", "Unknown", "Unknown")]
        public void CreateExaminer_IsTrue_Test(string name, string surname, string patronymic)
        {
            Assert.IsTrue(DaoFactory.GetDaoExaminer().TryCreateAsync(new Examiner(name, surname, patronymic)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadExaminer_IsNotNull_Test(int examinerId)
        {
            Assert.IsNotNull(DaoFactory.GetDaoExaminer().TryReadAsync(examinerId).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadExaminer_IsNull_Test(int examinerId)
        {
            Assert.IsNull(DaoFactory.GetDaoExaminer().TryReadAsync(examinerId).Result);
        }

        [TestMethod]
        [DataRow(1, "UnknownUpdate", "UnknownUpdate", "UnknownUpdate")]
        public void UpdateExaminer_IsTrue_Test(int id, string name, string surname, string patronymic)
        {
            Assert.IsTrue(DaoFactory.GetDaoExaminer().TryUpdateAsync(new Examiner(id, name, surname, patronymic)).Result);
        }

        [TestMethod]
        [DataRow(10, "UnknownUpdate", "UnknownUpdate", "UnknownUpdate")]
        public void UpdateExaminer_IsFalse_Test(int id, string name, string surname, string patronymic)
        {
            Assert.IsFalse(DaoFactory.GetDaoExaminer().TryUpdateAsync(new Examiner(id, name, surname, patronymic)).Result);
        }

        [TestMethod]
        [DataRow(3)]
        public void DeleteExaminer_IsTrue_Test(int examinerId)
        {
            Assert.IsTrue(DaoFactory.GetDaoExaminer().TryDeleteAsync(examinerId).Result);
        }

        [TestMethod]
        [DataRow(30)]
        public void DeleteExaminer_IsFalse_Test(int examinerId)
        {
            Assert.IsFalse(DaoFactory.GetDaoExaminer().TryDeleteAsync(examinerId).Result);
        }

        [TestMethod]
        public void ReadAllExaminers_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoExaminer().TryReadAllAsync().Result);
        }
    }
}