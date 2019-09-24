using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUp.Models;
using WhatsUp.Repositories;
using WhatsUp.Services;
using Xunit;

namespace WhatsUp.Tests.UnitTests
{
    public class AuthenticationTests
    {
        [Theory]
        [InlineData("New User", "newuser", "admin123")]
        public void Register_ValidCredentials(string name, string username, string password)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository<Account>>()
                    .Setup(x => x.Insert(It.IsAny<Account>()));
            }
        }


        [Theory]
        [InlineData("nick", "admin123")]
        public void Login_ValidCredentials(string username, string password)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository<Account>>()
                    .Setup(x => x.QueryOne(It.IsAny<Account>()))
                    .Returns(MockLogin(username, password));

                var mockAuthService = mock.Create<AuthService>();

                var expected = MockLogin(username, password);
                var actual = mockAuthService.Login(username, password);

                actual.Should().NotBeNull();
                actual.Should().BeEquivalentTo(expected);
            }
        }


        [Theory]
        [InlineData("IDoNotExist", "Password")] // Non existent username
        [InlineData("nick", "notadmin")] // Wrong password
        public void Login_WrongCredentials(string username, string password)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository<Account>>()
                    .Setup(x => x.QueryOne(It.IsAny<Account>()))
                    .Returns(MockLogin(username, password));

                var mockAuthService = mock.Create<AuthService>();

                var actual = mockAuthService.Login(username, password);

                actual.Should().BeNull();
            }
        }


        private Account MockLogin(string username, string password)
        {
            var Users = new List<Account>
            {
                new Account()
                {
                    Id = default,
                    Name = "Nick Versteeg",
                    Username = "nick",
                    Password = "admin123"
                }
            };

            return Users.Find(x => x.Username == username && x.Password == password);
        }

    }
}
