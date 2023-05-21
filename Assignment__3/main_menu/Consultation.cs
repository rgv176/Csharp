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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace main_menu
{
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();
        }

        //Load all the CoursName
        private void Consultation_Load(object sender, EventArgs e)
        {
            Business_Form1 bus = new Business_Form1();
            DataTable dt2 = bus.GetAllGrades();
            foreach (DataRow row in dt2.Rows)
            {
                comboBox1.Items.Add(row["CoursName"].ToString());
            }

        }

        //Load all the student's info and grade in function of the course and calculate the average grade of the class
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Business_Form1 bus = new Business_Form1();
                DataTable studentGrades = bus.GetStudentGradesByCourseName(comboBox1.SelectedItem.ToString());
                dataGridView1.DataSource = studentGrades;

                int totalGrades = 0;
                int numStudents = studentGrades.Rows.Count;

                foreach (DataRow row in studentGrades.Rows)
                {
                    totalGrades += int.Parse(row["Grade"].ToString());
                }

                double avgGrade = (double)totalGrades / numStudents;
                textBox1.Text = avgGrade.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
