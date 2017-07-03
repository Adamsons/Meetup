using FluentAssertions;
using MeetupTest.Api.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MeetupTest.Api.Tests.UnitTests.Validation
{
    public class ValidateModelAttributeTests
    {
        private ValidateModelAttribute _attribute = new ValidateModelAttribute();

        [Fact(DisplayName = "On action executing, when the model state is invalid, return a bad request result ")]
        public void OnActionExecuting_SetsBadRequestResult()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("Error", "Error");

            var actionContext = new ActionContext(
               new Mock<HttpContext>().Object,
               new Mock<RouteData>().Object,
               new Mock<ActionDescriptor>().Object,
               modelState);

            var executingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<Controller>());

            _attribute.OnActionExecuting(executingContext);

            executingContext.Result.Should().NotBeNull();
            executingContext.Result.Should().BeOfType<BadRequestObjectResult>();
        }


        [Fact(DisplayName = "On action executing, when the model state is invalid, return projected model state errors")]
        public void OnActionExecuting_ProjectsModelStateErrors()
        {
            var errorKey = "Error";
            var errorMessage = "Message";

            var modelState = new ModelStateDictionary();
            modelState.AddModelError(errorKey, errorMessage);

            var actionContext = new ActionContext(
               new Mock<HttpContext>().Object,
               new Mock<RouteData>().Object,
               new Mock<ActionDescriptor>().Object,
               modelState);

            var executingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<Controller>());

            _attribute.OnActionExecuting(executingContext);

            executingContext.Result.Should().NotBeNull();
            executingContext.Result.Should().BeOfType<BadRequestObjectResult>();

            var badRequestResult = executingContext.Result as BadRequestObjectResult;
            var validationResult = badRequestResult.Value as ValidationResultModel;

            validationResult.Errors.Should().NotBeNullOrEmpty();
            validationResult.Errors.Any(o => o.Field == errorKey && o.Message == errorMessage);
        }
    }
}
