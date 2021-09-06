using millionaire.Controllers;
using millionaire.Models;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;

namespace tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            var logger = new Mock<ILogger<HomeController>>();
            HomeController hc = new(logger.Object);

            var indexPage = hc.Index();

            Assert.NotNull(hc.Index());
        }
    }
}