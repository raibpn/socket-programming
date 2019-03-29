using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WCFPersonRestConsumer.CountryCodeService;

namespace WCFPersonRestConsumer
{
    public class Person
    {
        public int Pno { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }
        public Person()
        {

        }

        public Person(int pno, string name, string countryCode)
        {
            Pno = pno;
            Name = name;
            CountryCode = countryCode;
        }

        public override string ToString()
        {
            using (CountryCodeService.Service1Client codeService = new Service1Client("BasicHttpBinding_IService1"))
            {
                return $"Pno: {Pno}, Name : {Name}, {codeService.GetCountryDetailsByCode(CountryCode)}";

            }
        }

        private static async Task<IList<Person>> GetPersonAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string PersonsUri = "http://wcfpersonrest47.azurewebsites.net/PersonService.svc/persons/";
                string content = await client.GetStringAsync(PersonsUri);
                IList<Person> cList = JsonConvert.DeserializeObject<IList<Person>>(content);
                return cList;
            }
        }

        public static IList<Person> GetPersons()
        {
            return GetPersonAsync().Result;
        }

        public static void AddPerson(Person aPerson)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(aPerson);
                StringContent sc = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage result =
                    client.PostAsync("http://wcfpersonrest47.azurewebsites.net/PersonService.svc/persons/", sc).Result;
            }
        }
        public static void EditPerson(Person aPerson)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(aPerson);
                StringContent sc = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage result =
                    client.PutAsync("http://wcfpersonrest47.azurewebsites.net/PersonService.svc/persons/", sc).Result;
            }
        }

        public static void DeletePerson(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(id);
                StringContent sc =new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync("http://wcfpersonrest47.azurewebsites.net/PersonService.svc/persons/" + "/"+ id).Result;
            }
        }


    }
}
