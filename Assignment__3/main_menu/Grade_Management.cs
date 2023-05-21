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
    public partial class Grade_Management : Form
    {
        public Grade_Management()
        {
            InitializeComponent();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Load CoursName and StudentId in corresponding ComboBox
        private void Grade_Management_Load(object sender, EventArgs e)
        {
            Business_Form1 bus = new Business_Form1();
            DataTable dt = bus.GetAllStudentIds();
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["StudentId"].ToString());
            }
            DataTable dt2 = bus.GetAllGrades();
            foreach (DataRow row in dt2.Rows)
            {
                comboBox2.Items.Add(row["CoursName"].ToString());
            }
           
            
        }

        // Each time a new student is choose, we set his name + family in textbox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Business_Form1 bus = new Business_Form1();

            // Mettre à jour le nom de l'étudiant
            if (comboBox1.SelectedIndex >= 0)
            {
                int selectedId = int.Parse(comboBox1.SelectedItem.ToString());
                DataTable selectedStudent = bus.Search(selectedId);
                if (selectedStudent.Rows.Count > 0)
                {
                    textBox1.Text = selectedStudent.Rows[0]["Name"].ToString() + " " + selectedStudent.Rows[0]["Family"].ToString();
                }

            }
        }
        // Each time a new CoursName is choose, we set his the grade in textbox2 for the corresponding StudentId
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Business_Form1 bus = new Business_Form1();
            if (comboBox1.SelectedIndex >= 0)
            {
                int selectedId = int.Parse(comboBox1.SelectedItem.ToString());
                if (comboBox2.SelectedIndex >= 0)
                {
                    string selectedCourseName = comboBox2.SelectedItem.ToString();
                    DataTable selectedGrade = bus.GetGradeByStudentIdAndCourseName(selectedId, selectedCourseName);
                    if (selectedGrade.Rows.Count > 0)
                    {
                        textBox2.Text = selectedGrade.Rows[0]["Grade"].ToString();
                    }
                    // Otherwise we print that there is no grade
                    else
                    {
                        textBox2.Text = "No grade";
                    }
                }
            }

        }

        // To clean all the fields

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text=string.Empty;
            textBox2.Text=string.Empty;
        }
        // Add a new grade
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = int.Parse(comboBox1.SelectedItem.ToString());
                string coursName = comboBox2.SelectedItem.ToString();
                double grade = float.Parse(textBox2.Text);
                Business_Form1 bus = new Business_Form1();
                bus.AddGrade(studentId, coursName, grade);
                MessageBox.Show("ok");
            }catch(Exception ex)
            {
                MessageBox.Show("Everything must be fill and Grade must be integer");
            }
        }
        // Modify a grade
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Business_Form1 bus = new Business_Form1();
                int studentId = int.Parse(comboBox1.SelectedItem.ToString());
                string coursName = comboBox2.SelectedItem.ToString();
                int grade = Int32.Parse(textBox2.Text);
                bus.UpdateGrade(studentId, coursName, grade);
                MessageBox.Show("OK");
            }catch(Exception ex)
            {
                MessageBox.Show("Error when modifying grade. Try again !");
            }
        }
        // Display all the grades for corresponding student
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Business_Form1 bus = new Business_Form1();
                DataTable grades = bus.GetGradesByStudentId(Int32.Parse(comboBox1.SelectedItem.ToString()));
                dataGridView1.DataSource = grades;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Exit the application
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
