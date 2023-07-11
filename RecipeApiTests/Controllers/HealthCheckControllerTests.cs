using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;


namespace RecipeApi.Controllers.Test
{
    public class HealthCheckControllerTests
    {
        private readonly HealthCheckController _controller;
        private readonly Mock<ILogger<HealthCheckController>> _mockLogger;

        public HealthCheckControllerTests()
        {
            _mockLogger = new Mock<ILogger<HealthCheckController>>();
            _controller = new HealthCheckController(_mockLogger.Object);
        }

        [Fact]
        public void ShouldReturnsOkWhenHealthy()
        {
            Assert.IsType<OkResult>(_controller.CheckHealth());
        }
    }
}