using Kata.SuperMarketCheckout.Api.Dtos.Checkouts;
using Kata.SuperMarketCheckout.Api.Mappers.Checkouts;
using Kata.SuperMarketCheckout.Checkouts.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kata.SuperMarketCheckout.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutsController : ControllerBase
    {
        private readonly ICheckoutMapper _checkoutMapper;
        private readonly ICheckoutService _checkoutService;

        public CheckoutsController(ICheckoutMapper checkoutMapper, ICheckoutService checkoutService)
        {
            _checkoutMapper = checkoutMapper;
            _checkoutService = checkoutService;
        }

        [HttpPost(Name = "Checkout")]
        public async Task<IActionResult> PostAsync([FromBody] IEnumerable<CheckoutItemDto> checkoutItems)
        {
            var checkouts = checkoutItems.Select(_checkoutMapper.ToModel).ToList();

            var checkout = await _checkoutService.CheckoutItemsAsync(checkouts);

            return Ok(_checkoutMapper.ToDto(checkout));
        }
    }
}