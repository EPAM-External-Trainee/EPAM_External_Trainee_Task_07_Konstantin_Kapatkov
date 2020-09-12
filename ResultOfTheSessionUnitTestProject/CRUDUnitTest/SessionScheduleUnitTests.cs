using System;
using DAL.ORM.Models.SessionInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class SessionScheduleUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow(1, 1, 1, 2020, 12, 12, 1, 1)]
        public void CreateSessionSchedule_IsTrue_Test(int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId, int examinerId)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionSchedule().TryCreateAsync(new SessionSchedule(sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId, examinerId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadSessionSchedule_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoSessionSchedule().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void ReadSessionSchedule_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoSessionSchedule().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 2020, 5, 22, 1, 1)]
        public void UpdateSessionSchedule_IsTrue_Test(int id, int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId, int examinerId)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionSchedule().TryUpdateAsync(new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId, examinerId)).Result);
        }

        [TestMethod]
        [DataRow(100, 1, 1, 1, 2020, 5, 22, 1, 1)]
        public void UpdateSessionSchedule_IsFalse_Test(int id, int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId, int examinerId)
        {
            Assert.IsFalse(DaoFactory.GetDaoSessionSchedule().TryUpdateAsync(new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId, examinerId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void UpdateSessionSchedule_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionSchedule().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void UpdateSessionSchedule_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoSessionSchedule().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllSessionSchedules_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoSessionSchedule().TryReadAllAsync().Result);
        }
    }
}