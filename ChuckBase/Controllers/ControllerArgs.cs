using Microsoft.Extensions.Configuration;

namespace ChuckBase.Controllers
{
    public  class ControllerArgs
    {
        public ControllerArgs(IConfiguration configuration)
        {
            Configuration = configuration;
            BaseUrl = Configuration["JokeApi:BaseUrl"];
        }

        public string BaseUrl { get; set; }


        private readonly IConfiguration Configuration;
    }
}