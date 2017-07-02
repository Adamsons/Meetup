using MeetupTest.Api.Tests.ComponentTests.Helpers;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace MeetupTest.Api.Tests.ComponentTests
{
    public class BookingControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BookingControllerTests()
        {
            _server = TestServerFactory.CreateTestServer();
            _client = _server.CreateClient();
        }
    }
}
