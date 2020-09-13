using System;
using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Student"/> model</summary>
    [TestClass]
    public class StudentUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void CreateStudent_IsTrue_Test(string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsTrue(DaoFactory.GetDaoStudent().TryCreateAsync(new Student(name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadStudent_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoStudent().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void ReadStudent_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoStudent().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void UpdateStudent_IsTrue_Test(int id, string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsTrue(DaoFactory.GetDaoStudent().TryUpdateAsync(new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [TestMethod]
        [DataRow(100, "Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void UpdateStudent_IsFalse_Test(int id, string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsFalse(DaoFactory.GetDaoStudent().TryUpdateAsync(new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteStudent_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoStudent().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void DeleteStudent_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoStudent().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllStudents_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoStudent().TryReadAllAsync().Result);
        }
    }
}