using AGL.DevelopersTest.Interfaces;
using AGL.DevelopersTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AGL.DevelopersTest.Repositories
{
    public class PersonRepository:IPersonRepository
    {
        private const string URL = "http://agl-developer-test.azurewebsites.net/people.json";
        public  List<Person> GetPeople()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };
            HttpClient client = new HttpClient();
            HttpResponseMessage response =  client.GetAsync(URL).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<List<Person>>().Result;
        }
    }
}
