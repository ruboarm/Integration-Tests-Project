using IntegrationTestsWebApi.Context;
using IntegrationTestsWebApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestsRespawn.Setup
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly TestsService TestsService;
        protected readonly AppDbContext DbContext;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            TestsService = _scope.ServiceProvider.GetRequiredService<TestsService>();

            DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }
    }
}
