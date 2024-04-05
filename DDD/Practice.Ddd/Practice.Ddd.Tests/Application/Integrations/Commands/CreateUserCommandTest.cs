using Practice.Ddd.Application.Requests.Commands;

namespace Practice.Ddd.Tests.Application.Integrations.Queries
{
    [TestClass]
    public class CreateUserCommandTest : BaseMediatorRequestTest
    {
        [TestMethod]
        [DataRow(null, "a", "a", "When user name is null, query should be error")]
        [DataRow("", "b", "c", "When user name is empty, query should be error")]
        public async Task InvalidParameter_Should_Be_Error(string userName, string firstName, string lastName, string testMessage)
        {
            //Arrange
            var command = new CreateUserCommand(userName, firstName, lastName);

            //Act
            var result = await _mediator.Send(command);

            //Assert
            Assert.IsTrue(result.HasError, testMessage);
        }


    }
}