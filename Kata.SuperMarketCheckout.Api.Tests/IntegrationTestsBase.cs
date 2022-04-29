using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kata.SuperMarketCheckout.Api.Tests
{
    public class IntegrationTestsBase : IClassFixture<TestFixture>
    {
        public IntegrationTestsBase(TestFixture fixture)
        {
            Client = fixture.Client;
        }

        protected HttpClient Client { get; }
    }
}
