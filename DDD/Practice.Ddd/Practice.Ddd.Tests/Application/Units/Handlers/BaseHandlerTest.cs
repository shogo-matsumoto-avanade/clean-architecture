using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application;

namespace Practice.Ddd.Tests.Application.Units.Handlers;

public class BaseHandlerTest
{ 
    protected readonly IServiceProvider _servicesProvider;

    /// <summary>
    /// Provide dependency injection
    /// </summary>
    protected BaseHandlerTest()
    {
        var services = new ServiceCollection();
        _servicesProvider = services
            .AddApplication()
            .AddTestInfrastructure()
            .AddTestSettings()
            .BuildServiceProvider();

        AdditionalTestSetting();
    }

    /// <summary>
    /// Additional Test Settings
    /// </summary>
    protected virtual void AdditionalTestSetting() { }
}
