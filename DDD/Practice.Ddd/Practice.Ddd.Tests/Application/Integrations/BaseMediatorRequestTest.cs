using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application;

namespace Practice.Ddd.Tests.Application.Integrations;

/// <summary>
/// Mediator Request base class
/// </summary>
[TestClass]
public abstract class BaseMediatorRequestTest
{
    protected readonly IMediator _mediator;

    /// <summary>
    /// Provide dependency injection and setup IMediator
    /// </summary>
    protected BaseMediatorRequestTest()
    {
        var services = new ServiceCollection();
        var serviceProvider = services
            .AddApplication()
            .AddTestInfrastructure()
            .AddTestSettings()
            .BuildServiceProvider();

        _mediator = serviceProvider.GetRequiredService<IMediator>();

        AdditionalTestSetting();
    }

    /// <summary>
    /// Additional Test Settings
    /// </summary>
    protected virtual void AdditionalTestSetting() { }
}