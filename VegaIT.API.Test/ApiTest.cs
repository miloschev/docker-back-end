using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VegaIT.API;
using Xunit;
using System.Threading.Tasks;

namespace VegaIT.API.Test
{
    public class ApiTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        public ApiTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        //test poziva /user/all i proverava responce kod
        public async Task TestGetAll()
        {
            // Arrange
            var request = "/user/all";
            // Act
            var response = await Client.GetAsync(request);
            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        //test poziva /user/byId/2 i proverava responce kod
        public async Task TestGetById()
        {
            // Arrange
            var request = "/user/byId/2";
            // Act
            var response = await Client.GetAsync(request);
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
