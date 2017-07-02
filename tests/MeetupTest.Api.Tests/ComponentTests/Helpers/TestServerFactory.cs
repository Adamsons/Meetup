using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace MeetupTest.Api.Tests.ComponentTests.Helpers
{
    internal static class TestServerFactory
    {
        public static TestServer CreateTestServer()
        {
            return new TestServer(new WebHostBuilder()
              .UseContentRoot(Path.GetFullPath(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..", "..", "..", "..", "..", "src/MeetupTest.Api")))
              .UseEnvironment("Development")
              .UseStartup<Startup>());
        }
    }
}
