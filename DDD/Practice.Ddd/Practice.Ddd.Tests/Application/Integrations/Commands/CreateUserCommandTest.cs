using FluentAssertions;
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
        [DynamicData(nameof(InvalidCreateUserCommandData))]
        public async Task Command_will_occur_error_when_invalid_parameters(string firstName, string lastName, string email, string errorMessage, string testMessage)
        {
            //Arrange
            var command = new CreateUserCommand(firstName, lastName, email);

            //Act
            var result = await _mediator.Send(command);

            //Assert
            Assert.IsTrue(result.HasError, testMessage);
            Assert.AreEqual(errorMessage, result.Message);
        }

        public static IEnumerable<object[]> InvalidCreateUserCommandData => [
                    [null, "unittest", "xxx@xxx.xxx", "Validation failed: \r\n -- FirstName: 'First Name' は空であってはなりません。 Severity: Error", "When first name is null, query should be error"],
                    ["", "unittest", "xxx@xxx.xxx", "Validation failed: \r\n -- FirstName: 'First Name' は空であってはなりません。 Severity: Error", "When first name is empty, query should be error"],
                    ["test", null, "xxx@xxx.xxx", "Validation failed: \r\n -- FamilyName: 'Family Name' は空であってはなりません。 Severity: Error", "When family name is null, query should be error"],
                    ["test", "", "xxx@xxx.xxx", "Validation failed: \r\n -- FamilyName: 'Family Name' は空であってはなりません。 Severity: Error", "When family name is empty, query should be error"],
                    ["test", "unittest", null, "Validation failed: \r\n -- Email: 'Email' は空であってはなりません。 Severity: Error", "When email is null, query should be error"],
                    ["test", "unittest", "", "Validation failed: \r\n -- Email: 'Email' は空であってはなりません。 Severity: Error\r\n -- Email: 'Email' は正しい形式ではありません。 Severity: Error", "When email is empty, query should be error"],
                    ["test", "unittest", "a@b", "Validation failed: \r\n -- Email: 'Email' は正しい形式ではありません。 Severity: Error", "When email is invalid, query should be error"],
                    ["test", "unittest", "testmail@test.xxx.com", "The email testmail@test.xxx.com has been already regsitered", "When the emai already has been registered, query should be error"]
                ];


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

            Task.WaitAll();

            //Arrange
            var busMock = _servicesProvider.GetRequiredService<Mock<IBus>>();
            var domainLoggerMock = _servicesProvider.GetRequiredService<Mock<IDomainLogger>>();

            var query = new CreateUserCommand(firstName, familyName, email);

            //Act
            var result = await _mediator.Send(query);

            Task.WaitAll();

            //Assert
            result.Message.Should().BeEmpty();
            result.HasError.Should().BeFalse();
            var actualUser = await userRepository.FindByEmailAsync(new Email(email));
            actualUser.Should().NotBeNull();
            actualUser!.FirstName.Should().Be(firstName);
            actualUser.FamilyName.Should().Be(familyName);
            actualUser.Email.Should().Be(new Email(email));

            domainLoggerMock.Verify(x =>
                x.UserCreated(actualUser.Id, actualUser.UserName, actualUser.Email),
                Times.Once);
            busMock.Verify(x => x.SendAsync($"Sent SMS of {actualUser!.Id}:{actualUser.UserName}", default), Times.Once);
            busMock.Verify(x => x.SendAsync($"Sent Email to {actualUser!.Email}", default), Times.Once);
        }
    }
}