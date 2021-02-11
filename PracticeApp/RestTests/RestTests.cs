using Newtonsoft.Json;
using NUnit.Framework;
using PracticeApp.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.RestTests
{
    [TestFixture]
    public class RestTests
    {
        private string url = "https://reqres.in";
        private string endPoint = "/api/users?page=2";

        [Test]
        public void SimpleGetTest()
        {
            //Створюю обєкти клієнта і реквеста типу Get
            IRestClient restClient = new RestClient(url);
            IRestRequest restRequest = new RestRequest(endPoint, Method.GET);
            //restRequest.AddHeader("Accept", "application/json");
            //restRequest.RequestFormat = DataFormat.Json;

            //Виконую ревквест і отримую відповідь
            IRestResponse response = restClient.Execute(restRequest);
            //Відповідь десеріалізую
            UsersList users = JsonConvert.DeserializeObject<UsersList>(response.Content);

            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual("Michael", users.Data[0].First_Name);
        }
    }
}
