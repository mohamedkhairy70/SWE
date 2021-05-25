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
            using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
            {
                var getAwaitListDepartment = await work.Department.AllNotDeleted();
                var GetAwaitCourse = await work.Course.AllNotDeleted();
                var CourseResult = GetAwaitCourse.Select(f => new { f.Id, f.Name, NameDepartment = f.Department.Name }).ToList();
                var DepartmentResult = getAwaitListDepartment.Select(d => new { d.Id, d.Name }).ToList();
                GvResult.DataSource = CourseResult;
                if (DepartmentResult.Count > 0)
                {
                    cm_Department.DataSource = DepartmentResult;
                    cm_Department.DisplayMember = "Name";
                    cm_Department.ValueMember = "Id";
                    cm_Department.SelectedIndex = -1;
                }
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        async void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
            {
                var GetAwaitCourse = await work.Course.GetByName(_Name);
                var CourseResult = GetAwaitCourse.Select(f => new { f.Id, f.Name }).ToList();
                GvResult.DataSource = CourseResult;
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
                var NameCourses = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var IdCourses = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {NameCourses}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Update Entities (Id,Name,IsDeleted = true) for visable from my project Not my database
                    await implementCourse.Updated(Convert.ToInt32(IdCourses), NameCourses, true);
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
