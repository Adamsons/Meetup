using MeetupTest.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Api.Tests.UnitTests.Middleware
{
    public class ErrorLoggingMiddlewareTests
    {
        private ErrorLoggingMiddleware _middleware;
        private Mock<ILogger<ErrorLoggingMiddleware>> _logger;

        public ErrorLoggingMiddlewareTests()
        {
            _logger = new Mock<ILogger<ErrorLoggingMiddleware>>();
            _middleware = new ErrorLoggingMiddleware(new RequestDelegate((context) => throw new DivideByZeroException()), _logger.Object);
        }

        [Fact]
        public async Task Invoke_LogsWhenExceptionIsThrown()
        {
            await _middleware.Invoke(new DefaultHttpContext());
            _logger.Verify(o => o.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<object>(), It.IsAny<DivideByZeroException>(), It.IsAny<Func<object, Exception, string>>()));
        }
    }
}
