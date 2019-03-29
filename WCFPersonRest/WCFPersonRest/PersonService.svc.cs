using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFPersonRest.Model;

namespace WCFPersonRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : IPersonService
    {
        private static List<Person> persons = new List<Person>()
        {
            new Person(10, "Peter", "ky"),
            new Person(13,"Deepak", "np")
        };
        public IList<Person> GetPersons()
        {
            return persons;
        }

        public Person GetAllPersonById(string id)
        {
            int ix = int.Parse(id);
            return persons.Find(p => p.Pno == ix);
        }

        public void DeletePersonById(string id)
        {
            int iid = Convert.ToInt32(id);
            //List<Person> toDel = new List<Person>();
            //foreach (Person aPerson in persons)
            //{
            //    if (aPerson.Pno.Equals(iid))
            //    {
            //        toDel.Add(aPerson);
            //    }
            //}
            //if (toDel != null)
            //{
            //    foreach (Person toDelP in toDel)
            //    {
            //        persons.Remove(toDelP);
            //    }
            //}
            persons.RemoveAll(p => p.Pno.Equals(iid));
        }

        public IList<Person> CreatePerson(Person person)
        {
            persons.Add(person);
            return persons;
        }
        public IList<Person> EditPerson(Person person)
        {
            foreach (var aPerson in persons)
            {
                if (aPerson.Pno == person.Pno)
                {
                    aPerson.Name = person.Name;
                    aPerson.CountryCode = person.CountryCode;
                }

            }
            return persons;
        }
    }
}
 