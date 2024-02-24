using Testcontainers.PostgreSql;

namespace OnlineStore.Infrastructure.IntegrationTests.Fixtures
{
    public class PostgreSqlFixture : IAsyncLifetime
    {
        public string ConnectionString => _container.GetConnectionString();
        private readonly PostgreSqlContainer _container = new PostgreSqlBuilder()
            .Build();

        public Task InitializeAsync()
        {
            return _container.StartAsync();
        }
        public Task DisposeAsync()
        {
            return _container.DisposeAsync().AsTask();
        }
    }
}
