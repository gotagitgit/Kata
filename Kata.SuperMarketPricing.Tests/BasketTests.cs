using System;
using FluentAssertions;
using Kata.SupermarketPricing.Models;
using Kata.SupermarketPricing.Models.PriceSchemes;
using Kata.SupermarketPricing.Models.UOMs;
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
            var product = new Product(Guid.NewGuid(), "Bundled Product", 1, UnitOfMeasure.pc, new BundledProductPriceScheme());

            var basket = Basket.Empty;

            var basketItem = new BasketItem(product, quantity, UnitOfMeasure.pc);

            // Act
            var result = basket.AddItem(basketItem);

            // Assert
            result.Total.Should().Be(totalPrice);
        }

        [Theory]
        [InlineData(2, UnitOfMeasure.Kg, 8.77)]
        [InlineData(20, UnitOfMeasure.oz, 2.49)]
        [InlineData(10, UnitOfMeasure.lb, 19.9)]
        public void Should_compute_converted_price_scheme(double quantity, UnitOfMeasure uom, double totalPrice)
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Bundled Product", 1.99, UnitOfMeasure.lb, new ConvertedPriceScheme());

            var basket = Basket.Empty;

            var basketItem = new BasketItem(product, quantity, uom);

            // Act
            var result = basket.AddItem(basketItem);

            // Assert
            result.Total.Should().Be(totalPrice);
        }
    }
}
