using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main_menu
{
    public partial class Student_Management : Form
    {
        public Student_Management()
        {
            InitializeComponent();
        }
      

        // Clean all the fields
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text= string.Empty;
            textBox2.Text= string.Empty;
            textBox3.Text= string.Empty;
        
        }
        // Add a new Student
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Int32.Parse(textBox1.Text);
                string studentName = textBox2.Text;
                string studentFamily = textBox3.Text;
                DateTime dt = dateTimePicker1.Value.Date;
                Business_Form1 business = new Business_Form1();
                business.AddStudent(studentId, studentName, studentFamily, dt);
                MessageBox.Show("Student added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // Delete a student with his ID
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Int32.Parse(textBox1.Text);
                Business_Form1 business = new Business_Form1();
                business.DeleteStudent(studentId);
                MessageBox.Show("Student Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Update a student
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Int32.Parse(textBox1.Text);
                string studentName = textBox2.Text;
                string studentFamily = textBox3.Text;
                DateTime dt = dateTimePicker1.Value.Date;
                Business_Form1 business = new Business_Form1();
                business.UpdateStudent(studentId, studentName, studentFamily, dt);
                MessageBox.Show("Student Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Search for a student with his ID
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            Business_Form1 bus = new Business_Form1();
            DataTable dt = bus.Search(id);
            if (dt.Rows.Count > 0)
            {
                textBox2.Text = dt.Rows[0]["Name"].ToString();
                textBox3.Text = dt.Rows[0]["Family"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["BirthDate"]);
            }
            else
            {
                MessageBox.Show("No student find with this ID");
            }
        }
        // Exit the application
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
       

       
    }
}
