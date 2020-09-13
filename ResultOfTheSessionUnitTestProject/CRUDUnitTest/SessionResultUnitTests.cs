using DAL.ORM.Models.SessionInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    /// <summary>Class describes testing CRUD functionality for <see cref="SessionResult"/> model</summary>
    [TestClass]
    public class SessionResultUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow(1, 1, "8", 1)]
        [DataRow(2, 1, "Passed", 1)]
        public void CreateSessionResult_IsTrue_Test(int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionResult().TryCreateAsync(new SessionResult(subjectId, studentId, assessment, sessionId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadSessionResult_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoSessionResult().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void ReadSessionResult_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoSessionResult().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, 1, 1, "5", 1)]
        public void UpdateSessionResult_IsTrue_Test(int id, int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionResult().TryUpdateAsync(new SessionResult(id, subjectId, studentId, assessment, sessionId)).Result);
        }

        [TestMethod]
        [DataRow(100, 1, 1, "5", 1)]
        public void UpdateSessionResult_IsFalse_Test(int id, int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsFalse(DaoFactory.GetDaoSessionResult().TryUpdateAsync(new SessionResult(id, subjectId, studentId, assessment, sessionId)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteSessionResult_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoSessionResult().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(100)]
        public void DeleteSessionResult_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoSessionResult().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllSessionResults_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoSessionResult().TryReadAllAsync().Result);
        }
    }
}