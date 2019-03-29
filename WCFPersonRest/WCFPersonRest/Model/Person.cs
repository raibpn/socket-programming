using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFPersonRest.Model
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
            return $"Pno: {Pno}, Name : {Name}, Country: {CountryCode}";
        }
    }
}