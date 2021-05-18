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
    public partial class frm_Department : Form
    {

        public frm_Department()
        {
            InitializeComponent();
        }

        
        void Updated(int _Id, string _Name,bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Facultie.Update(new Facultie { Id = _Id, Name = _Name,IsDelete = _IsDelete });

                work.Commet();
            }

        }
        void Add(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Facultie.Add(new Facultie { Name = _Name });

                work.Commet();
            }
            
        }
        void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetFuc = work.Facultie.AllNotDeleted().Select(f =>  new {f.Id,f.Name }).ToList();
                GvResult.DataSource = GetFuc;
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetFuc = work.Facultie.GetByName(_Name).Select(f => new { f.Id, f.Name }).ToList();
                GvResult.DataSource = GetFuc;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //For Get All Data and Clear Data
            get();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GvResult.Columns[e.ColumnIndex].Name == "Edit")
            {
                txt_Id.Text = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txt_Name.Text = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            }
            if (GvResult.Columns[e.ColumnIndex].Name == "Delete")
            {
                var NameFaculties = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var IdFaculties = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {NameFaculties}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Update Entities (Id,Name,IsDeleted = true) for visable from my project Not my database
                    Updated(Convert.ToInt32(IdFaculties), NameFaculties, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                //For Add Entities (Id auto No Bas,Name)
                Add(txt_Name.Text);
                //For Get All Data and Clear Data
                get();
            }
            else
            {
                //For Update Entities (Id,Name,IsDeleted)
                Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text,false);
                //For Get All Data and Clear Data
                get();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //For Get Data By Name and Clear Data
            getByName(txt_Name.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //For Get Data and Clear Data
            get();
        }
    }
}
