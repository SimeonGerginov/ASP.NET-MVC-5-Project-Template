using MVC5_Template.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MVC5_Template.Tests.UnitTests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView_WhenCalled()
        {
            // Arrange
            var homeController = new HomeController();

            // Act && Assert
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
