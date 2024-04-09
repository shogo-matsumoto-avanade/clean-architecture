using Microsoft.Extensions.DependencyInjection;
using Moq;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Application.Requests.Commands;
using Practice.Ddd.Application.Services;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Infrastructure.Services;

namespace Practice.Ddd.Tests.Application.Integrations.Queries
{
    [TestClass]
    public class CreateUserCommandTest : BaseMediatorRequestTest
    {
        [TestMethod]
        [DataRow(null, "a", "xxx@xxx", "When first name is null, query should be error")]
        [DataRow("", "b", "xxx@xxx", "When first name is empty, query should be error")]
        public async Task FirstName_Is_Required(string firstName, string lastName, string email, string testMessage)
        {
            //Arrange
            var command = new CreateUserCommand(firstName, lastName, email);

            //Act
            var result = await _mediator.Send(command);

            //Assert
            Assert.IsTrue(result.HasError, testMessage);
        }

        [TestMethod]
        [DataRow("test", "integration", "it@test.xxx.com")]
        public async Task Create_Valid_User(string firstName, string familyName, string email)
        {
            //Precondiction
            var unitOfWork = _servicesProvider.GetRequiredService<IUnitOfWork>();
            var userRepository = _servicesProvider.GetRequiredService<IUserRepository>();
            var user = await userRepository.FindByEmailAsync(new Email(email));
            if (user is not null)
            {
                userRepository.Remove(user);
                await unitOfWork.SaveChangesAsync();
            }

            //Arrange
            var busMock = _servicesProvider.GetRequiredService<Mock<IBus>>();
            var domainLoggerMock = _servicesProvider.GetRequiredService<Mock<IDomainLogger>>();

            var query = new CreateUserCommand(firstName, familyName, email);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            var actualUser = await userRepository.FindByEmailAsync(new Email(email));
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(actualUser.FirstName, firstName);
            Assert.AreEqual(actualUser.FamilyName, familyName);
            Assert.AreEqual(actualUser.Email, new Email(email));

            domainLoggerMock.Verify(x =>
                x.UserCreated(actualUser.Id, actualUser.UserName, actualUser.Email.Value),
                Times.Once);
            busMock.Verify(x => x.SendAsync($"Sent SMS of {actualUser!.Id}:{actualUser.UserName}"), Times.Once);
            busMock.Verify(x => x.SendAsync($"Sent Email to {actualUser!.Email}"), Times.Once);
        }
    }
}