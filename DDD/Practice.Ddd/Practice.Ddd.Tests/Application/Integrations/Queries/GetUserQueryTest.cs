using Practice.Ddd.Application.Requests.Queries;

namespace Practice.Ddd.Tests.Application.Integrations.Queries
{
    [TestClass]
    public class GetUserQueryTest : BaseMediatorRequestTest
    {
        [TestMethod]
        [DataRow(null, "When id is null, query should be error")]
        [DataRow("", "When id is empty, query should be error")]
        public async Task InvalidParameter_Should_Be_Error(string id, string testMessage)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            Assert.IsTrue(result.HasError, testMessage);
            Assert.AreEqual(result.Message, "Value cannot be null. (Parameter 'UserId')", testMessage);
        }

        [TestMethod]
        [DataRow("test", "first name last name", "When id is {0}, user {1} is expected.")]
        public async Task Find_Existing_User(string id, string userName, string testMessageTemplate)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            var message = string.Format(testMessageTemplate, id, userName);
            Assert.IsFalse(result.HasError, message);
            Assert.AreEqual(result.Message, string.Empty, message);
            Assert.AreEqual(userName, result.UserName, message);
        }

        [TestMethod]
        [DataRow("aaaa", "Unknown", "Search unknown user")]
        public async Task Find_NOT_Existing_User(string id, string userName, string testMessageTemplate)
        {
            //Arrange
            var query = new FindUserByIdQuery(id);

            //Act
            var result = await _mediator.Send(query);

            //Assert
            var message = string.Format(testMessageTemplate, id, userName);
            Assert.IsFalse(result.HasError, message);
            Assert.AreEqual(result.Message, string.Empty, message);
            Assert.AreEqual(userName, result.UserName, message);
        }

    }
}