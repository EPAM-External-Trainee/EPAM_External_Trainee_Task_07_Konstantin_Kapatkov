using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject.CRUDUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Examiner"/> model</summary>
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
        public void ReadExaminer_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoExaminer().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadExaminer_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoExaminer().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown", "Unknown", "Unknown")]
        public void UpdateExaminer_IsTrue_Test(int id, string name, string surname, string patronymic)
        {
            Assert.IsTrue(DaoFactory.GetDaoExaminer().TryUpdateAsync(new Examiner(id, name, surname, patronymic)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown", "Unknown", "Unknown")]
        public void UpdateExaminer_IsFalse_Test(int id, string name, string surname, string patronymic)
        {
            Assert.IsFalse(DaoFactory.GetDaoExaminer().TryUpdateAsync(new Examiner(id, name, surname, patronymic)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteExaminer_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoExaminer().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteExaminer_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoExaminer().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllExaminers_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoExaminer().TryReadAllAsync().Result);
        }
    }
}