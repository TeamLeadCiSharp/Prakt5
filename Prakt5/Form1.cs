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
        Students students = new Students();
        string path = "data.txt";
        public void Show(DataGridView dg)
        {
            dg.Rows.Clear();
            foreach (Student student in students.students)
            {
                dg.Rows.Add(student.FullName, student.Course, student.Group, student.RunningResult);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                students.WriteFile(path);
                MessageBox.Show("Дані записані!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при записі даних: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                students.ReadFile(path);
                Show(dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при читанні даних: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox5.Text, Convert.ToDouble(textBox3.Text));
                students.Add(student);
                dataGridView2.Rows.Add(student.FullName, student.Course, student.Group, student.RunningResult);
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка у форматі введених даних!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Переповнення при конвертації числа!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка у вхідних даних: {ex.Message}");
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            var i = dataGridView2.CurrentRow.Index;
            students.Remove(i);
            Show(dataGridView2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            students.Sort();
            Show(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            students.students.Sort();
            dataGridView1.Rows.Clear();
            foreach (Student student in students.students)
            {
                if (student.RunningResult > Convert.ToDouble(textBox4.Text))
                {
                    dataGridView1.Rows.Add(student.FullName, student.Course, student.Group, student.RunningResult);
                }
            }
        }

    }
}
