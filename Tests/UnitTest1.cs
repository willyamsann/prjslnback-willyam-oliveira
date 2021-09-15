using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Service.Validators;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {

        private readonly HttpClient _client;
        private AbstractValidator<User> Validator { get; }
        public UnitTest1()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var server = new TestServer(new WebHostBuilder()
                 .UseConfiguration(configuration)
                 .UseStartup<Startup>());

            _client = server.CreateClient();
            Validator = new UserValidator();

        }
  
        [Theory]
        [InlineData("POST")]
        public async Task TestAutenticadGeneric(string method)
        {
            //using (var client = new UnitTest1()._client)
            //{
            //    var response = await client.PostAsync("/api/User/authenticateGeneric",null);

            //    response.EnsureSuccessStatusCode();

            //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //}
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/User/authenticateGeneric");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void  TestValidatePassword()
        {
            var user = new User()
            {
                Name = "WIllyam",
                Email = "teste@email.com",
                Password = "Wil@090414DeusEFiel"
            };

            Assert.Equal(true, Validator.Validate(user).IsValid);
            //}

        }



    }
}
