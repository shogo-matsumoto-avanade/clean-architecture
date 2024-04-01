using Castle.Core.Logging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Practice.Ddd.Application;
using Practice.Ddd.Application.Handlers;
using Practice.Ddd.Application.Queries;
using Practice.Ddd.Infrastructure;
using Practice.Ddd.Infrastructure.Users;

namespace Practice.Ddd.Tests.Application
{
    [TestClass]
    public class GetUserQueryTest
    {
        [TestMethod]
        [DataRow(null, "When id is null, query should be error")]
        [DataRow("", "When id is empty, query should be error")]
        public async Task GetUserQuery_InvalidParameter_Should_Be_Error(string id, string testMessage)
        {
            //Arrange
            var services = new ServiceCollection();
            var serviceProvider = services
                .AddApplication()
                .AddInfrastructure()
                .AddTest()
                .BuildServiceProvider();

            var mediator = serviceProvider.GetRequiredService<IMediator>();
            var query = new GetUserQuery(id);

            //Act
            var result = await mediator.Send(query);

            //Assert
            Assert.IsTrue(result.HasError, testMessage);
            Assert.AreEqual(result.Message, "Value cannot be null. (Parameter 'UserId')", testMessage);
            return;
        }
    }
}