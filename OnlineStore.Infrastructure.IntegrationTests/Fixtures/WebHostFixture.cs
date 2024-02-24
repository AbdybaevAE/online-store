using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace OnlineStore.Infrastructure.IntegrationTests.Fixtures
{
    public class WebHostFixture
    {

        protected TestServer TestServer;
        public WebHostFixture()
        {
            TestServer = new TestServer(
                       new WebHostBuilder()
                        );
        }
    }
}
