using FluentAssertions;
using Practice.Ddd.Application.Requests.Queries;

namespace Practice.Ddd.Tests.Application.Integrations.Queries
{
    [TestClass]
    public class GetUserByIdQueryTest : BaseMediatorRequestTest
    {
        [TestMethod]
        [DataRow(null, "When id is null, query should be error")]
        [DataRow("", "When id is empty, query should be error")]
        public async Task UserId_Is_Required(string id, string testMessage)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            result.HasError.Should().BeTrue(testMessage);
            result.Message.Should().Be("Validation failed: \r\n -- Id: 'Id' ÇÕãÛÇ≈Ç†Ç¡ÇƒÇÕÇ»ÇËÇ‹ÇπÇÒÅB Severity: Error", testMessage);
        }

        [TestMethod]
        [DataRow("test-id", "test user", "testmail@test.xxx.com", "When id is {0}, user {1} is expected.")]
        public async Task Find_Existing_User(string id, string userName, string email, string testMessageTemplate)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            var message = string.Format(testMessageTemplate, id, userName);
            result.HasError.Should().BeFalse(message);
            result.Message.Should().Be(string.Empty, message);
            result.UserName.Should().Be(userName, message);
            result.Email.Should().Be(email, message);
        }

        [TestMethod]
        [DataRow("aaaa", "Search unexisting user")]
        public async Task Find_NOT_Existing_User(string id, string testMessage)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            result.HasError.Should().BeTrue(testMessage);
            result.Message.Should().Be($"User is not found by Id : {id}", testMessage);
        }

    }
}