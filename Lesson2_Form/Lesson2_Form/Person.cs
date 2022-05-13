using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_form
{
    class Person
    {
        public string city { get; set; }
        public int experienceYears { get; set; }
        public string firstName { get; set; }
        public LanguageKnowledge[] languages { get; set; }
        public string lastName { get; set; }
        public int[] marks { get; set; }

        public Person()
        {

        }
        public Person(string city, int experienceYears, string firstName, LanguageKnowledge[] languages, string lastName, int[] marks)
        {
            this.city = city;
            this.experienceYears = experienceYears;
            this.firstName = firstName;
            this.languages = languages;
            this.lastName = lastName;
            this.marks = marks;
        }
    }
}
