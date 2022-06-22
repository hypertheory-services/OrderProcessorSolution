
using OrderProcessorApi.Controllers;

namespace OrderProcessorApi.IntegrationTests;

public class PlacingAnOrderNeedsAuthentication : IClassFixture<FixtureBase>
{

    private readonly IAlbaHost _host;

    public PlacingAnOrderNeedsAuthentication(FixtureBase fixture)
    {
        _host = fixture.AlbaHost;
    }

    [Fact]
    public async Task RequiresAuthentication()
    {
        var response = await _host.Scenario(api =>
        {
            var cart = new ShoppingCart(new string[] { "hat", "coat" }, "Expedite");

            api.Post.Json(cart).ToUrl("/my/orders");
            api.StatusCodeShouldBe(401);
        });
    }
}

