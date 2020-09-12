using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResultOfTheSessionUnitTestProject.CRUDUnitTest;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class KnowledgeAssessmentFormUnitTests : CRUDUnitTestData
    {
        [TestMethod]
        [DataRow("Unknown")]
        public void CreateKnowledgeAssessmentForm_IsTrue_Test(string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoKnowledgeAssessmentForm().TryCreateAsync(new KnowledgeAssessmentForm(name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void ReadKnowledgeAssessmentForm_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetDaoKnowledgeAssessmentForm().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void ReadKnowledgeAssessmentForm_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetDaoKnowledgeAssessmentForm().TryReadAsync(id).Result);
        }

        [TestMethod]
        [DataRow(1, "Unknown")]
        public void UpdateKnowledgeAssessmentForm_IsTrue_Test(int id, string name)
        {
            Assert.IsTrue(DaoFactory.GetDaoKnowledgeAssessmentForm().TryUpdateAsync(new KnowledgeAssessmentForm(id, name)).Result);
        }

        [TestMethod]
        [DataRow(10, "Unknown")]
        public void UpdateKnowledgeAssessmentForm_IsFalse_Test(int id, string name)
        {
            Assert.IsFalse(DaoFactory.GetDaoKnowledgeAssessmentForm().TryUpdateAsync(new KnowledgeAssessmentForm(id, name)).Result);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteKnowledgeAssessmentForm_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetDaoKnowledgeAssessmentForm().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        [DataRow(10)]
        public void DeleteKnowledgeAssessmentForm_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetDaoKnowledgeAssessmentForm().TryDeleteAsync(id).Result);
        }

        [TestMethod]
        public void ReadAllKnowledgeAssessmentForms_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetDaoKnowledgeAssessmentForm().TryReadAllAsync().Result);
        }
    }
}