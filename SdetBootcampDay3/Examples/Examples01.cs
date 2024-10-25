using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace SdetBootcampDay3.Examples
{
    [TestFixture]
    public class Examples01
    {
        private const string BASE_URL = "https://icanhazdadjoke.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetRandomJoke_CheckStatusCode_ShouldBeHttpStatusCodeOK()
        {
            //Create request pass endpoint and get
            RestRequest request = new RestRequest("/", Method.Get);

            //wait for response
            RestResponse response = await client.ExecuteAsync(request);

            //check response is correct (gets ok)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetRandomJoke_CheckStatusCode_ShouldBe200()
        {
            RestRequest request = new RestRequest("/", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            //in this case, status code needs to be converted to an int
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetJokeR7UfaahVfFd_CheckContentType_ShouldContainApplicationJson()
        {
            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            // does the value of the content type header contain the substring
            Assert.That(response.ContentType, Does.Contain("application/json"));
        }

        [Test]
        public async Task GetJokeR7UfaahVfFd_CheckCFCacheStatus_ShouldBeDynamic()
        {
            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            //headers is unordered collection of header parameter objects
            //header has name and value properties
            //give me the header paramter with the name CF Cache Status, get the value, and then get the first value (likely will be only one)
            //linq syntax goes over iterable list of objects
            string serverHeaderValue = response.Headers!
                .Where(x => x.Name.Equals("CF-Cache-Status"))
                .Select(x => x.Value)
                .First();

            //assert value is correct
            Assert.That(serverHeaderValue, Is.EqualTo("DYNAMIC"));
        }

        [Test]
        //check on response body
        public async Task GetJokeR7UfaahVfFd_CheckJoke_ShouldBeBad()
        {
            string expectedJoke = "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.";

            RestRequest request = new RestRequest("/j/R7UfaahVfFd", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            //convert to json object first
            //if this fails then json is badly formatted
            JObject responseData = JObject.Parse(response.Content!);

            //give value of joke element and get as a string, then compare to expected 
            Assert.That(responseData.SelectToken("joke")!.ToString(), Is.EqualTo(expectedJoke));
        }
    }
}
