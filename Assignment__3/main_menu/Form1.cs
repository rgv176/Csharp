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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Consultation cs=new Consultation();
            cs.MdiParent = Form1.ActiveForm;
            cs.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Student_Management sm= new Student_Management();
            sm.MdiParent = Form1.ActiveForm;
            sm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Grade_Management gm= new Grade_Management();
            gm.MdiParent = Form1.ActiveForm;
            gm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
