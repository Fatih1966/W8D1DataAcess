using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWStudent
{
    public partial class Form1 : Form
    {

        SchoolEntities context = new SchoolEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from per in context.People
                                        where per.Discriminator=="Student"
                                        select new
                                        {
                                            per.PersonID,
                                            per.Discriminator,
                                            per.FirstName,
                                            per.LastName,
                                            per.EnrollmentDate,
                                        }).ToList();

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Index value of the row clicked
            int rowIndex = e.RowIndex;


            //Row object in dataGridView
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            textBox1.Text = row.Cells[0].Value.ToString();
            comboBox1.Text = row.Cells[1].Value.ToString();
            textBox7.Text = row.Cells[2].Value.ToString();
            textBox8.Text = row.Cells[3].Value.ToString();
            textBox9.Text = row.Cells[4].Value.ToString();
        }
        /// <summary>
        /// Modifies the data of an existing Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text.ToString());

            var student = context.People.Find(id);
            student.Discriminator = comboBox1.Text;
            student.FirstName = textBox7.Text;
            student.LastName = textBox8.Text;
            student.EnrollmentDate = Convert.ToDateTime(textBox9.Text);

            context.Entry<Person>(student).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            dataGridView1.DataSource = (from per in context.People
                                        where per.Discriminator == "Student"
                                        select new
                                        {
                                            per.PersonID,
                                            per.Discriminator,
                                            per.FirstName,
                                            per.LastName,
                                            per.EnrollmentDate,
                                        }).ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// Adds a new student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var student = new Person();
            student.Discriminator = comboBox1.Text;
            student.FirstName = textBox7.Text;
            student.LastName = textBox8.Text;
            student.EnrollmentDate = Convert.ToDateTime(textBox9.Text);

            context.People.Add(student);

            context.SaveChanges();
            dataGridView1.DataSource = (from per in context.People
                                        where per.Discriminator == "Student"
                                        select new
                                        {
                                            per.PersonID,
                                            per.Discriminator,
                                            per.FirstName,
                                            per.LastName,
                                            per.EnrollmentDate,
                                        }).ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text.ToString());
            var student = context.People.Find(id);
            context.People.Remove(student);
            context.SaveChanges();
            dataGridView1.DataSource = (from per in context.People
                                        where per.Discriminator == "Student"
                                        select new
                                        {
                                            per.PersonID,
                                            per.Discriminator,
                                            per.FirstName,
                                            per.LastName,
                                            per.EnrollmentDate,
                                        }).ToList();

        }
    }
}
