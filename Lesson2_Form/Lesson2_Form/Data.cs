using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_form
{
    static class Data
    {
        public static List<Person> People { get; set; } =
            new List<Person>
            {
                new Person{city="Tel Aviv", experienceYears= 1, firstName= "Avi",
            languages= new LanguageKnowledge[] { new LanguageKnowledge { knowledgeLevel=4, language="C#" } },
            lastName= "Levi", marks= new int[] {95,97,98 } },

        new Person{city="Jerusalem", experienceYears= 5, firstName= "Chaim", languages= new LanguageKnowledge[]
            { new LanguageKnowledge { knowledgeLevel=6, language="Java" },
            new LanguageKnowledge{ knowledgeLevel=9, language="Python" } },
            lastName= "Frid", marks= new int[] { 99, 97 } } 
            };
        public static List<Company> Companies { get; set; } =
             new List<Company>
        {
           new Company{city="Jerusalem", name= "Mobily", proffession= eProffession.Developing },
        new Company{ city="Tel Aviv", name= "Intel", proffession= eProffession.QA } ,
        new Company{ city="Tel Aviv", name= "Apple", proffession= eProffession.Developing }
        };
    }
}
