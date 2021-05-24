using SWE.UI.ImplementForms;
using SWE.UI.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SWE.UI.Forms
{
    public partial class frm_Course : Form
    {
        ImplementCourse implementCourse;
        public frm_Course()
        {
            InitializeComponent();
            implementCourse = new ImplementCourse();
        }

        
        
        async void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetAwaitFacultie = await work.Facultie.AllNotDeleted();
                var FacultieResult = GetAwaitFacultie.Select(f => new { f.Id, f.Name }).ToList();
                GvResult.DataSource = FacultieResult;
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        async void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetAwaitFacultie = await work.Facultie.GetByName(_Name);
                var FacultieResult = GetAwaitFacultie.Select(f => new { f.Id, f.Name }).ToList();
                GvResult.DataSource = FacultieResult;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //For Get All Data and Clear Data
            get();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    await implementCourse.Updated(Convert.ToInt32(IdFaculties), NameFaculties, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                //For Add Entities (Id auto No Bas,Name)
                await implementCourse.Add(txt_Name.Text);
                //For Get All Data and Clear Data
                get();
            }
            else
            {
                //For Update Entities (Id,Name,IsDeleted)
                await implementCourse.Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text,false);
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
