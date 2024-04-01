using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application;
using Practice.Ddd.Infrastructure;

namespace Practice.Ddd.Tests.Application.Integrations;

[TestClass]
public abstract class BaseMediatorRequestTest
{
    protected readonly IMediator _mediator;

    protected BaseMediatorRequestTest()
    {
        var services = new ServiceCollection();
        var serviceProvider = services
            .AddApplication()
            .AddInfrastructure()
            .AddTest()
            .BuildServiceProvider();

        _mediator = serviceProvider.GetRequiredService<IMediator>();

        AdditionalTestSetting();
    }
    protected virtual void AdditionalTestSetting() { }
}