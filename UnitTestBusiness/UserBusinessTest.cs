using System;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.Elevator.Business.Master;
using Moq;
using FluentAssertions;
using Epam.Elevator.Models.Master;

namespace UnitTestBusiness
{
    [TestClass]
    public class UserBusinessTest
    {
        [TestMethod]
        public void GetTest()
        {
            User user = new User
            {
                UserId = 1,
                FirstName = "Shruthi",
                LastName="Nadigoti"
            };
            Mock<UserDataAccess> mockUserDataAccess = new Mock<UserDataAccess>();
            mockUserDataAccess.Setup(x => x.Get(2)).Returns(user);
            var userBusiness = new UserBusiness(mockUserDataAccess.Object);
            userBusiness.Get(10);
            userBusiness.Should().NotBeNull();
        }
    }
}
