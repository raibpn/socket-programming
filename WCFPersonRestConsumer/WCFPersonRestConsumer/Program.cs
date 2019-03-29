using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFPersonRestConsumer.CountryCodeService;

namespace WCFPersonRestConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var aperson in Person.GetPersons())
            {
                Console.WriteLine(aperson);
            } 

            Person.AddPerson(new Person(1113,"Ramma","dk"));

            Console.WriteLine("after add");
            foreach (var aperson in Person.GetPersons())
            {
                Console.WriteLine(aperson);
            }

           

            Person.EditPerson(new Person(1113,"Ram","gg"));
            Console.WriteLine("after edit");
            foreach (var aperson in Person.GetPersons())
            {
                Console.WriteLine(aperson);
            }
            Person.DeletePerson("1113");
            Console.WriteLine("after del");
            foreach (var aperson in Person.GetPersons())
            {
                Console.WriteLine(aperson);
            }


            Console.ReadKey();
        }
          
    }
}
