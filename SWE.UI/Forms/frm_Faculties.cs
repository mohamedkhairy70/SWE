using SWE.UI.interfaces;
using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWE.UI.Forms
{
    public partial class frm_Faculties : Form
    {

        public frm_Faculties()
        {
            InitializeComponent();
        }
        void Add()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Facultie.Add(new Facultie { Name = textBox1.Text });

                work.Commet();
            }
            
        }
        void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetFuc = work.Facultie.All().ToList();
                dataGridView1.DataSource = GetFuc;
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Add();
            get();
        }
    }
}
