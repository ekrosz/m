using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Praktika_1
{
    public partial class Form1 : Form
    {
        private List<Person> persons = new List<Person>()
        {
            new Person
            {
                Name = "Иван",
                Role = Role.Admin,
                Age = 30
            },
            new Person
            {
                Name = "Петр",
                Role = Role.Employee,
                Age = 23
            }
        };

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = persons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var xmlSerializer = new XmlSerializer(persons.GetType());

            using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
            {
                persons = (List<Person>)xmlSerializer.Deserialize(fs);
                dataGridView1.DataSource = persons;
            }

            // Персоны старше 20 лет сгруппированные по ролям.

            // LINQ через лямбды
            var linqGrouping = persons.Where(p => p.Age > 20).GroupBy(p => p.Role);

            // Классический LINQ
            var classicGrouping = from person in persons
                      where person.Age > 20
                      group person by person.Role;
                      
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var xmlSerializer = new XmlSerializer(persons.GetType());

            using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, persons);
            }
        }
    }
}
