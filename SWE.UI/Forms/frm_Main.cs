using System;
using System.Windows.Forms;

namespace SWE.UI.Forms
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_Faculties();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_Department();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frm_Professor();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new frm_Student();
            frm.ShowDialog();

        }
    }
}
