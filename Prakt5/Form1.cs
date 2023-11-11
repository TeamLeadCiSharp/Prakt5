using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prakt5
{
    public partial class Form1 : Form
    {
        People people = new People();
        string path = "data.txt";
        public void Show(DataGridView dg)
        {
            dg.Rows.Clear();
            foreach (Person p in people.people)
            {
                dg.Rows.Add(p.Name, p.Age, p.Weight);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var person = new Person(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                people.people.Add(person);
                dataGridView2.Rows.Add(people.people[people.people.Count - 1].Name,
                    people.people[people.people.Count - 1].Age,
                    people.people[people.people.Count - 1].Weight);
            }
            catch (Exception)
            {
                throw new Exception("Помилка у вхідних данних!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            people.WriteFile(path);
            MessageBox.Show("Дані записані!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            people.ReadFile(path);
            Show(dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var i = dataGridView2.CurrentRow.Index;
            people.Remove(i);
            Show(dataGridView2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            people.Sort();
            Show(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            people.people.Sort();
            dataGridView1.Rows.Clear();
            foreach (Person p in people.people)
            {
                if (p.Weight>Convert.ToDouble(textBox4.Text))
                {
                    dataGridView1.Rows.Add(p.Name, p.Age, p.Weight);
                }
            }
        }
    }
}
