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
        IUnitOfWork<Facultie> work;
        IRepository<Facultie> RFacultie;
        public frm_Faculties()
        {
            InitializeComponent();
            work = new UnitOfWork<Facultie>(new SWEContext());
            RFacultie = new Repository<Facultie>(new SWEContext());
        }
        void Add()
        {
            RFacultie.Add(new Facultie { Name = textBox1.Text });

            work.Commet();
        }
        void get()
        {
            work.Commet();
            var GetFuc = RFacultie.All();
            dataGridView1.DataSource = GetFuc.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                Add();
                
            }
            get();

            //Add();
            //get();
        }
    }
}
