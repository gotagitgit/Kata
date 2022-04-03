using System;
using FluentAssertions;
using Kata.SupermarketPricing.Models;
using Kata.SupermarketPricing.Models.PriceSchemes;
using Xunit;

namespace Kata.SuperMarketPricing.Tests
{
    public class BasketTests
    {
        [Theory]
        [InlineData(8, 6)]
        [InlineData(2, 2)]
        public void Should_compute_bundled_products_price_scheme(
            double quantity,
            double totalPrice)
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Bundled Product", 1, new BundledProductPriceScheme());

            var basket = Basket.Empty;

            var basketItem = new BasketItem(product, quantity);

            // Act
            var result = basket.AddItem(basketItem);

            // Assert
            result.Total.Should().Be(totalPrice);
        }
    }
}
