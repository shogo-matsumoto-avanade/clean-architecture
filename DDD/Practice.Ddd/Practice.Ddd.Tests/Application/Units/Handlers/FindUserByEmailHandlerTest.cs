using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Handlers;
using Practice.Ddd.Application.Requests.Queries;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Tests.Application.Units.Handlers;

[TestClass]
public class FindUserByEmailHandlerTest : BaseUnitTest
{

    [TestMethod]
    [DataRow("testmail@test.xxx.com", "test user", "Find existing user")]
    [DataRow("test@test.xxx.com", "Unknown", "Find not existing user")]
    public async Task Find_Valid_Existing_User(string email, string expectedUserName, string testMessage)
    {
        //Arrange
        var repository = _servicesProvider.GetRequiredService<IUserRepository>();
        var handler = new FindUserByEmailHandler(repository);
        var query = new FindUserByEmailQuery(email);
        var cancellationToken = new CancellationToken();

        //Act
        var result = await handler.Handle(query, cancellationToken);

        //Assert
        Assert.AreEqual(expectedUserName, result.UserName, testMessage);
    }

}
