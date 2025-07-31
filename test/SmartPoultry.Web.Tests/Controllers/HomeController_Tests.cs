using System.Threading.Tasks;
using SmartPoultry.Models.TokenAuth;
using SmartPoultry.Web.Controllers;
using Shouldly;
using Xunit;

namespace SmartPoultry.Web.Tests.Controllers
{
    public class HomeController_Tests: SmartPoultryWebTestBase
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