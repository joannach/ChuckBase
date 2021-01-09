using ChuckBase.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostSharp.Patterns.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChuckBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        public JokeController(ControllerArgs args)
        {
            this.args = args;
            httpClient = new HttpClient();
        }

        // GET: api/<JokeController>
        [HttpGet]
        [Log(AttributeExclude = true)]
        public async Task<string> GetJoke()
        {
            var url = string.Format("{0}/{1}", args.BaseUrl, baseUrl);
            var response = await httpClient.GetAsync(url);

            return await GetReturnValue(response);
        }

        // GET api/<JokeController>/5
        [HttpGet("{category}")]
        [Log(AttributeExclude = true)]
        public async Task<string> GetJokeByCategory(string category)
        {
            var url = string.Format("{0}/{1}?category={2}", args.BaseUrl, baseUrl, category);
            var response = await httpClient.GetAsync(url);

            return await GetReturnValue(response);
        }


        private static async Task<string> GetReturnValue(HttpResponseMessage response)
        {
            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var joke = JsonConvert.DeserializeObject<Joke>(jsonString);
                return joke.Value;
            }
            return responseNullMessage;
        } 

        private const string baseUrl = "jokes/random";
        private const string responseNullMessage = "Try again!";
        private readonly ControllerArgs args;
        private readonly HttpClient httpClient;
    }
}
