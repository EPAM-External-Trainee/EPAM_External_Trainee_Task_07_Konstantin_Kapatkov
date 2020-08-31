using System;
using DAL.DAO.Models;
using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private DaoFactory daoFactory = DaoFactory.GetInstance(@"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;");

        [TestMethod]
        public void TestMethod1()
        {
            Gender gender = new Gender("Unknown");
            daoFactory.GetGender().Create(gender);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Gender gender = daoFactory.GetGender().Read(1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Gender gender = new Gender(3, "NewUnknown");
            daoFactory.GetGender().Update(gender);
        }

        [TestMethod]
        public void TestMethod4()
        {
            daoFactory.GetGender().Delete(4);
        }
    }
}