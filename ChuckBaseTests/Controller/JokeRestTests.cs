using ChuckBase.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ChuckBaseTests.Controller
{
    public class JokeRestTests
    {
        [Test]
        public void GetJoke_ReturnsJoke()
        {
            var controller = PrepareStuff();

            var response = controller.GetJoke();

            Assert.IsTrue(response.Result is string);
            Assert.IsTrue(response.Result.Contains("Chuck Norris"));
        }

        [Test]
        public void GetJokeByCategory()
        {
            var controller = PrepareStuff();

            var response = controller.GetJokeByCategory("animal");

            Assert.IsTrue(response.Result is string);
            Assert.IsTrue(response.Result.Contains("Chuck Norris"));
        }


        private JokeController PrepareStuff()
        {
            var args = new ControllerArgs(A.Fake<IConfiguration>())
            {
                BaseUrl = baseUrl
            };
            return new JokeController(args);
        }

        private readonly string baseUrl = "https://api.chucknorris.io/";
    }
}
