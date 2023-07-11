using System.Threading.Tasks;
using TypeTester.Models.TokenAuth;
using TypeTester.Web.Controllers;
using Shouldly;
using Xunit;

namespace TypeTester.Web.Tests.Controllers
{
    public class HomeController_Tests: TypeTesterWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}