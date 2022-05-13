using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_form
{
    class LanguageKnowledge
    {
        public int knowledgeLevel { get; set; }
        public string language { get; set; }

        public LanguageKnowledge()
        {

        }
        public LanguageKnowledge(int knowledgeLevel, string language)
        {
            this.knowledgeLevel = knowledgeLevel;
            this.language = language;
        }
    }
}
