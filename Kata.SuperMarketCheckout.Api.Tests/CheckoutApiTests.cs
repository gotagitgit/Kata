using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Kata.SuperMarketCheckout.Api.Dtos.Checkouts;
using Kata.SuperMarketCheckout.Stocks.Models;
using Newtonsoft.Json;
using Xunit;

namespace Kata.SuperMarketCheckout.Api.Tests
{
    public class CheckoutApiTests : IntegrationTestsBase, IAsyncLifetime
    {
        public CheckoutApiTests(TestFixture testFixture) : base(testFixture)
        {
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async void Should_Calculate_Total_Price_Async()
        {
            // Arrange
            var checkoutItems = new List<CheckoutItemDto>
            {
                CreateCheckoutItem(),
                CreateCheckoutItem(),
                CreateCheckoutItem()
            };

            // Act
            var response = await Client.PostAsJsonAsync("Checkouts", checkoutItems);

            // Assert
            var checkout = await ReadJsonAsync<CheckoutDto>(response);
            checkout.Total.Should().Be(4);
            checkout.Stocks.Count.Should().Be(1);
            checkout.Stocks.Single().Quantity.Should().Be(3);
        }

        private static async Task<T> ReadJsonAsync<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static CheckoutItemDto CreateCheckoutItem()
        {
            return new CheckoutItemDto
            {
                Sku = new Guid("aeecb15e-0f97-45bd-81cd-f21aa5d856a1"),
                Quantity = 1,
                Uom = UnitOfMeasure.pc
            };
        }
    }
}