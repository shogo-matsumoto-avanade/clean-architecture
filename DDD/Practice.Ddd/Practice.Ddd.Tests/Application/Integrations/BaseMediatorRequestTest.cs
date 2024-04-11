using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application;
using Practice.Ddd.Domain;

namespace Practice.Ddd.Tests.Application.Integrations;

/// <summary>
/// Mediator Request base class
/// </summary>
[TestClass]
public abstract class BaseMediatorRequestTest
{
    protected readonly IServiceProvider _servicesProvider;
    protected readonly IMediator _mediator;

    /// <summary>
    /// Provide dependency injection and setup IMediator
    /// </summary>
    protected BaseMediatorRequestTest()
    {
        var services = new ServiceCollection();
        _servicesProvider = services
            .AddApplication()
            .AddDomain()
            .AddTestPersistence()
            .AddTestInfrastructure()
            .BuildServiceProvider();

        _mediator = _servicesProvider.GetRequiredService<IMediator>();

        AdditionalTestSetting();
    }

    /// <summary>
    /// Additional Test Settings
    /// </summary>
    protected virtual void AdditionalTestSetting() { }
}