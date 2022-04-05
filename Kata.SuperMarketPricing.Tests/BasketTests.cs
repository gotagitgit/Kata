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
            var product = new Product(Guid.NewGuid(), "Bundled Product", 1, string.Empty, new BundledProductPriceScheme());

            var basket = Basket.Empty;

            var basketItem = new BasketItem(product, quantity, 1);

            // Act
            var result = basket.AddItem(basketItem);

            // Assert
            result.Total.Should().Be(totalPrice);
        }

        [Theory]
        [InlineData(1, "pound", 1, 1.99)]
        [InlineData(2, "pound", 1, 3.98)]
        [InlineData(1, "ounces", 0.25, 0.50)]
        [InlineData(2, "ounces", 0.25, 1)]
        public void Should_compute_product_with_different_unit_of_measure(
            double quantity,
            string unitOfMeasure,
            double uomConversion,
            double totalPrice)
        {
            var product = new Product(Guid.NewGuid(), "Pound Product", 1, unitOfMeasure, new OuncesToPoundsScheme());

            var basket = Basket.Empty;

            var basketItem = new BasketItem(product, quantity, uomConversion);

            var result = basket.AddItem(basketItem);

            result.Total.Should().Be(totalPrice);
        }
    }
}
