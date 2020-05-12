using Allure.Commons;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject.Tests
{
    [AllureNUnit]
    [TestFixture]
    class RestApiTests
    {
        private RestClient restClient;
        private int newId;
        
        [SetUp]
        public void Setup()
        {
            restClient = new RestClient("http://jsonplaceholder.typicode.com/");
        }

        [Test]
        [AllureTag("TC-Api")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("REST Api Suite")]
        [AllureSubSuite("Api")]
        public void ValidateThatAPIwillReturn100PostsViaGET()
        {
            RestRequest request = new RestRequest("/posts", Method.GET);

            var response = restClient.Execute<List<TestResult>>(request);

            Assert.AreEqual(true, response.IsSuccessful);
            Assert.AreEqual(100, response.Data.Count);
        }

        [Test]
        [AllureTag("TC-Api")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("REST Api Suite")]
        [AllureSubSuite("Api")]
        public void ValidatePostTitleWhereId1()
        {
            RestRequest request = new RestRequest("/posts?id=1", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            var response = restClient.Execute<List<Posts>>(request);

            var content = response.Data;

            var title = content[0].title;

            Assert.That(title, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"), "Title not correct");
        }

        [Test]
        [AllureTag("TC-Api")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("REST Api Suite")]
        [AllureSubSuite("Api")]
        public void ValidatePostTitleWhereId2()
        {
            var request = new RestRequest("/posts/2", Method.GET);
            var response = restClient.Execute(request);

            var deserialize = new JsonDeserializer();

            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var title = output["title"];

           Assert.That(title, Is.EqualTo("qui est esse"), "Title not correct");
        }

        [Test]
        [AllureTag("TC-Api")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("REST Api Suite")]
        [AllureSubSuite("Api")]
        public void ValidateCreationOfNewUserViaPOST()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            newId = randomNumber;

            RestClient client = new RestClient("http://localhost:3000");
            var NewUser = new Users
            {
                id = randomNumber,
                firstName = "Valera",
                lastName = "doe",
                email = "valera@gmail.com",
                age = 25,
                companyId = 1
            };
            var request = new RestRequest("/users", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(NewUser);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();

            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var title = output["lastName"];

            Assert.That(title, Is.EqualTo("doe"), "Last name is not correct");
        }

        [Test]
        [AllureTag("TC-Api")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("REST Api Suite")]
        [AllureSubSuite("Api")]
        public void ValidateAbilityToDelete()
        {
            RestClient client = new RestClient("http://localhost:3000");
            var NewUser = new Users
            {
                id = 25,
                firstName = "Valera",
                lastName = "doe",
                email = "valera@gmail.com",
                age = 25,
                companyId = 1
            };
            var request = new RestRequest("/users", Method.POST);
            request.Method = Method.POST;
            request.AddJsonBody(NewUser);
            var response = client.Execute<Users>(request);

            Assert.AreEqual(true, response.IsSuccessful);
            request = new RestRequest("/users/{id}");
            request.AddUrlSegment("id", response.Data.id);
            request.Method = Method.DELETE;
            var result = client.Execute<Users>(request);
            Assert.AreEqual(true, response.IsSuccessful);
            request.Method = Method.GET;
            result = client.Execute<Users>(request);
            Assert.That(result.IsSuccessful, Is.False);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
