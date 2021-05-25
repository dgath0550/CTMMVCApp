using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;

namespace CTMAPIAppTests
{
    public class FizzBuzzTests
    {
        public FizzBuzzTests()
        {
            SetUpClient();
        }

        [Theory]
        [InlineData(15)]
        [InlineData(2)]
        [InlineData(25)]
        [InlineData(100)]
        public async void FizzBuzz(int n)
        {
            var result =  await GetResponseAsync("/home/fizzbuzz/" + n);
            var output = await result.Content.ReadAsStringAsync();
            if(n == 15)
                Assert.Equal("[\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\",\"Fizz\",\"7\",\"8\",\"Fizz\",\"Buzz\",\"11\",\"Fizz\",\"13\",\"14\",\"FizzBuzz\"]", output);
            if (n == 2)
                Assert.Equal("[\"1\",\"2\"]", output);
            if (n == 25)
                Assert.Equal("[\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\",\"Fizz\",\"7\",\"8\",\"Fizz\",\"Buzz\",\"11\",\"Fizz\",\"13\",\"14\",\"FizzBuzz\",\"16\",\"17\",\"Fizz\",\"19\",\"Buzz\",\"Fizz\",\"22\",\"23\",\"Fizz\",\"Buzz\"]", output);
            if (n == 100)
                Assert.Equal("[\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\",\"Fizz\",\"7\",\"8\",\"Fizz\",\"Buzz\",\"11\",\"Fizz\",\"13\",\"14\",\"FizzBuzz\",\"16\",\"17\",\"Fizz\",\"19\",\"Buzz\",\"Fizz\",\"22\",\"23\",\"Fizz\",\"Buzz\",\"26\",\"Fizz\",\"28\",\"29\",\"FizzBuzz\",\"31\",\"32\",\"Fizz\",\"34\",\"Buzz\",\"Fizz\",\"37\",\"38\",\"Fizz\",\"Buzz\",\"41\",\"Fizz\",\"43\",\"44\",\"FizzBuzz\",\"46\",\"47\",\"Fizz\",\"49\",\"Buzz\",\"Fizz\",\"52\",\"53\",\"Fizz\",\"Buzz\",\"56\",\"Fizz\",\"58\",\"59\",\"FizzBuzz\",\"61\",\"62\",\"Fizz\",\"64\",\"Buzz\",\"Fizz\",\"67\",\"68\",\"Fizz\",\"Buzz\",\"71\",\"Fizz\",\"73\",\"74\",\"FizzBuzz\",\"76\",\"77\",\"Fizz\",\"79\",\"Buzz\",\"Fizz\",\"82\",\"83\",\"Fizz\",\"Buzz\",\"86\",\"Fizz\",\"88\",\"89\",\"FizzBuzz\",\"91\",\"92\",\"Fizz\",\"94\",\"Buzz\",\"Fizz\",\"97\",\"98\",\"Fizz\",\"Buzz\"]", output);
        }

        private TestServer _server;
        public HttpClient Client { get; private set; }

        /// <summary>
        /// Sets up client
        /// </summary>
        private void SetUpClient()
        {
            var builder = new WebHostBuilder()
                .UseStartup<CTMMVCApp.Startup>()
                .ConfigureServices(services =>
                {
                    //Aditional services
                });

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        /// <summary>
        /// Makes a Get request
        /// </summary>
        /// <param name="uri">URL endpoint</param>
        /// <returns>Response data</returns>
        public async Task<HttpResponseMessage> GetResponseAsync(string uri)
        {
            var response = await Client.GetAsync(uri);
            return response;
        }
    }
}
