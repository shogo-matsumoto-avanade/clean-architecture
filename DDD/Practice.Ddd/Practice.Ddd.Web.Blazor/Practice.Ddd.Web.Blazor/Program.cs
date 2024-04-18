using Practice.Ddd.Application;
using Practice.Ddd.Infrastructure;
using Practice.Ddd.Persistence;
using Practice.Ddd.Web.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// [Customize] Add api endopoints
builder.Services.AddControllers();

// [Customize] Add services of the application
builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddInfrastructure();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Practice.Ddd.Web.Blazor.Client._Imports).Assembly);

// [Customize] Add mapping controllers
app.MapControllers();

app.Run();
