using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2_form
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>() 
        { new Person{city="Tel Aviv", experienceYears= 1, firstName= "Avi", 
            languages= new LanguageKnowledge[] { new LanguageKnowledge { knowledgeLevel=4, language="C#" } }, 
            lastName= "Levi", marks= new int[] {95,97,98 } },

        new Person{city="Jerusalem", experienceYears= 5, firstName= "Chaim", languages= new LanguageKnowledge[]
            { new LanguageKnowledge { knowledgeLevel=6, language="Java" },
            new LanguageKnowledge{ knowledgeLevel=9, language="Python" } },
            lastName= "Frid", marks= new int[] { 99, 97 } },

        new Person{city="Jerusalem", experienceYears= 0, firstName= "Michal", languages= new LanguageKnowledge[]
            { new LanguageKnowledge { knowledgeLevel=7, language="Java-script" },
            new LanguageKnowledge{ knowledgeLevel=5, language="Jquery" } },
            lastName= "klain", marks= new int[] { 99, 97 } }
        };


        List<Company> companies = new List<Company>() 
        { new Company{city="Jerusalem", name= "Mobily", proffession= eProffession.Developing },
        new Company{ city="Tel Aviv", name= "Intel", proffession= eProffession.QA },
        new Company{ city="Tel Aviv", name= "Appel", proffession= eProffession.Developing }
        };
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = (from c in people
                     orderby c.lastName, c.firstName
                     select c);
            dataGridView1.DataSource = q.ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = from c1 in people
                    where c1.experienceYears > 2
                    where c1.city == "Jerusalem"
                    select c1;
            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = (from c2 in people
                    where c2.experienceYears > 2
                    where c2.city == "Jerusalem"
                    select c2);
            label1.Text = q.Count().ToString();
            //dataGridView1.DataSource = q.Count();
            //לא הצלחתי
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var q = (from c3 in people
                     let avg= c3.marks.Average()
                     where avg > 95
                     where c3.city == "Jerusalem"
                     select new { c3.lastName, c3.firstName, c3.city, c3.experienceYears, avg } );
            dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = (from c3 in people
                     orderby c3.marks.Count() descending
                     let count= c3.marks.Count()
                     select new { c3.lastName,c3.firstName, count_of_marks= count});
            dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var q = from c3 in people
                     //orderby c3.city
                     //let count = c3.city.Count()
                     group c3 by c3.city;
            foreach (var item in q)
            {
                var q1 = from c in item select new { lastname = c.lastName, firstname = c.firstName, city = c.city };
                MessageBox.Show("now its city:"+item.Key);
                dataGridView1.DataSource = q1.ToList();
                MessageBox.Show("now its count:");
                label2.Text = q1.Count().ToString();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var q = (from c3 in people
                     
                     join c4 in companies on c3.city equals c4.city
                     where c3.experienceYears < 2
                     where c3.city== c4.city
                     select new {c4.name, c4.city, c3.lastName, c3.firstName, c3.experienceYears});
            dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var q = (from c3 in people
                     where c3.languages[0].knowledgeLevel > 2
                     select new { c3.lastName, c3.firstName, c3.languages[0].language, c3.languages[0].knowledgeLevel });
            dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = (from Company c3 in Data.Companies
                     where c3.city=="Tel Aviv"
                     orderby c3.name
                     select c3);
            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = from Company c in Data.Companies
                    group c by c.proffession;
            int max = 0;
            Company max_prof=new Company();
            foreach (var item in q)
            {
                var q1 = from c in item select new { name=c.name, proffession = c.proffession, city = c.city };
                MessageBox.Show("now its the proffession: " + item.Key);
                dataGridView1.DataSource = q1.ToList();
                MessageBox.Show("now its the count:");
                //label2.Text = q1.Count().ToString();
                if(q1.Count()>max)
                {
                    max = q1.Count();
                    max_prof.proffession = item.Key;
                }
            }
            MessageBox.Show("now its the common proffession: "+ max_prof.proffession);
            label2.Text = max_prof.proffession.ToString();
            var s = from c in companies group c by c.proffession into t orderby t.Count() select t.First();
            label2.Text = s.First().ToString();
            label2.Text = s.First().ToString();
        }


    }
}
