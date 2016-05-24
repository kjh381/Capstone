using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.ApplicationServices;

namespace SARDT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        //[TestMethod]
        //public void ShouldAuthenticateValidUser()
        //{
        //    IMyMockDa mockDa = new MockDataAccess();
        //    var service = new AuthenticationService(mockDa);

        //    mockDa.AddUser("Name", "Password");

        //    Assert.IsTrue(service.DoLogin("Name", "Password"));

        //    //Ensure data access layer was used
        //    Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
        //}

        //[TestMethod]
        //public void ShouldNotAuthenticateUserWithInvalidPassword()
        //{
        //    IMyMockDa mockDa = new MockDataAccess();
        //    var service = new AuthenticationService(mockDa);

        //    mockDa.AddUser("Name", "Password");

        //    Assert.IsFalse(service.LogIn("Name", "BadPassword"));

        //    //Ensure data access layer was used
        //    Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
        //}
    }
}
