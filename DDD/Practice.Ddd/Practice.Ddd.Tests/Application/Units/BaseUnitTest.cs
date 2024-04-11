using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application;
using Practice.Ddd.Domain;

namespace Practice.Ddd.Tests.Application.Units;

public class BaseUnitTest
{
    protected readonly IMediator _mediator;
    protected readonly IServiceProvider _servicesProvider;

    /// <summary>
    /// Provide dependency injection
    /// </summary>
    protected BaseUnitTest()
    {
        var services = new ServiceCollection();
        _servicesProvider = services
            .AddUnitTestApplication()
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
