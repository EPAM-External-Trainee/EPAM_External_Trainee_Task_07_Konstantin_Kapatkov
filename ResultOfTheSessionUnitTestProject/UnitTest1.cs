using System;
using DAL.DAO.Models;
using DAL.ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResultOfTheSessionUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Gender gender = new Gender("Unknown");
            DaoGender daoGender = new DaoGender();
            daoGender.Create(gender);
        }
    }
}
