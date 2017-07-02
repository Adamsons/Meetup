using FluentAssertions;
using MeetupTest.Api.Tests.ComponentTests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Api.Tests.ComponentTests
{
    public class MeetupComponentTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public MeetupComponentTests()
        {
            _server = TestServerFactory.CreateTestServer();
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetAllMeetups()
        {
            var response = await _client.GetAsync("/api/v1/meetups");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
