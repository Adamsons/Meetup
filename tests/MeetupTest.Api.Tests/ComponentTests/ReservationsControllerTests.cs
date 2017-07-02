using MeetupTest.Api.Tests.ComponentTests.Helpers;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace MeetupTest.Api.Tests.ComponentTests
{
    public class ReservationsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ReservationsControllerTests()
        {
            _server = TestServerFactory.CreateTestServer();
            _client = _server.CreateClient();
        }
    }
}
