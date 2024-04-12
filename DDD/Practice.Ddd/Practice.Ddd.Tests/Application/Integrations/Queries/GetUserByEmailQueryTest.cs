using FluentAssertions;
using Practice.Ddd.Application.Requests.Queries;

namespace Practice.Ddd.Tests.Application.Integrations.Queries
{
    [TestClass]
    public class GetUserByEmailQueryTest : BaseMediatorRequestTest
    {
        [TestMethod]
        [DataRow(null, "Validation failed: \r\n -- Email: 'Email' は空であってはなりません。 Severity: Error", "When email is null, query should be error")]
        [DataRow("", "Validation failed: \r\n -- Email: 'Email' は空であってはなりません。 Severity: Error\r\n -- Email: 'Email' は正しい形式ではありません。 Severity: Error", "When email is empty, query should be error")]
        [DataRow("aa@aaa", "Validation failed: \r\n -- Email: 'Email' は正しい形式ではありません。 Severity: Error", "When email is invalid format, query should be error")]
        public async Task Email_Is_Invalid(string email, string expectedErrorMessage, string testMessage)
        {
            //Arrange
            var query = new FindUserByEmailQuery(email);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            result.HasError.Should().BeTrue(testMessage);
            result.Message.Should().Be(expectedErrorMessage, testMessage);
        }

        [TestMethod]
        [DataRow("test user", "testmail@test.xxx.com", "When email is {0}, user {1} is expected.")]
        public async Task Find_Existing_User(string userName, string email, string testMessageTemplate)
        {
            //Arrange
            var query = new FindUserByEmailQuery(email);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            var message = string.Format(testMessageTemplate, email, userName);
            result.HasError.Should().BeFalse(message);
            result.Message.Should().Be(string.Empty, message);
            result.UserName.Should().Be(userName, message);
            result.Email.Should().Be(email, message);
        }

        [TestMethod]
        [DataRow("aa@aa.aaa", "Search unexisting user")]
        public async Task Find_NOT_Existing_User(string email, string testMessage)
        {
            //Arrange
            var query = new FindUserByEmailQuery(email);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            result.HasError.Should().BeTrue(testMessage);
            result.Message.Should().Be($"User is not found by Email : {email}", testMessage);
        }

    }
}