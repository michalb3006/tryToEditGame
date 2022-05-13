using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_form
{
    enum eProffession
    {
        Developing, QA
    }
    class Company
    {
        public string city { get; set; }
        public string name { get; set; }
        public eProffession proffession { get; set; }
        public Company()
        {

        }
        public Company(string city, string name, eProffession proffession)
        {
            this.city = city;
            this.name = name;
            this.proffession = proffession;
        }
    }
}
