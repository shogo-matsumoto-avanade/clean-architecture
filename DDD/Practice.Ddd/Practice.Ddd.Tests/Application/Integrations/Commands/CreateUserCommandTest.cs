using Practice.Ddd.Application.Requests.Commands;

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


    }
}