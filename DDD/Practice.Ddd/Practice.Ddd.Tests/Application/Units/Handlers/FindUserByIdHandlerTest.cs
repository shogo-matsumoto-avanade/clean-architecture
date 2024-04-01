using Practice.Ddd.Application.Handlers;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Infrastructure.Users;

namespace Practice.Ddd.Tests.Application.Units.Handlers;

[TestClass]
public class FindUserByIdHandlerTest
{

    [TestMethod]
    [DataRow("test")]
    public async Task Find_Valid_Existing_User(string id)
    {
        //Arrange
        var repository = new InMemoryUserRepository();
        var handler = new FindUserByIdHandler(repository);
        var query = new FindUserByIdQuery(id);
        var cancellationToken = new CancellationToken();

        //Act
        var result = await handler.Handle(query, cancellationToken) ;

        //Assert
        Assert.AreEqual("test name", result.UserName);
    }
}
