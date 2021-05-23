using SWE.UI.ImplementForms;
using SWE.UI.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SWE.UI.Forms
{
    public partial class frm_Department : Form
    {
        ImplementDepartment implementDepartment;
        public frm_Department()
        {
            InitializeComponent();
            implementDepartment = new ImplementDepartment();
        }
        async void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var getawaitListFacultie = await work.Facultie.AllNotDeleted();
                var getawaitListProfessor = await work.Professor.AllNotDeleted();


                var getawaitListDepartment = await work.Department.AllNotDeleted();
                var DepartmentResult = getawaitListDepartment.Select(f => new
                                        {
                                            f.Id,
                                            f.Name,
                                            NameFacultie = (f.FacultieId == null) ? null : f.Facultie.Name,
                                            NameProfessor = (f.ProfessorManageId == null) ? null : f.ProfessorManage.Name
                                        }).ToList();


                var ProfessorResult = getawaitListProfessor.Select(p => new { p.Id,p.Name }).ToList();
                var FacultieResult = getawaitListFacultie.Select(p => new { p.Id, p.Name }).ToList();

                if (FacultieResult.Count > 0)
                {
                    cm_Faculties.DataSource = FacultieResult;
                    cm_Faculties.DisplayMember = "Name";
                    cm_Faculties.ValueMember = "Id";
                    cm_Faculties.SelectedIndex = -1;
                }
                if (ProfessorResult.Count > 0)
                {
                    cm_Professor.DataSource = ProfessorResult;
                    cm_Professor.DisplayMember = "Name";
                    cm_Professor.ValueMember = "Id";
                    cm_Professor.SelectedIndex = -1;
                }

                GvResult.DataSource = DepartmentResult.ToList();
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        async void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {

                var getawaitListDepartment = await work.Department.AllNotDeleted();
                var DepartmentResult = getawaitListDepartment.Select(f => new
                {
                    f.Id,
                    f.Name,
                    NameFacultie = (f.FacultieId == null) ? null : f.Facultie.Name,
                    NameProfessor = (f.ProfessorManageId == null) ? null : f.ProfessorManage.Name
                }).ToList();
                GvResult.DataSource = DepartmentResult.ToList();
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
                var nameDepartment = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var idDepartment = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {nameDepartment}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Delete Entities (IdDepartment,NameDepartment,IdFaculties,IsDeleted = true) for visable from my project Not my database
                    await implementDepartment.Deleted(Convert.ToInt32(idDepartment), nameDepartment, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_Id.Text) && cm_Faculties.SelectedIndex >= 0)
            {
                
                int? profManage = null;
                if (cm_Professor.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_Professor.SelectedValue);
                }
                //For Add Entities (IdDepartment auto No Bas,NameDepartment,IdFacultie)
                await implementDepartment.Add(txt_Name.Text, Convert.ToInt32(cm_Faculties.SelectedValue), profManage);
                //For Get All Data and Clear Data
                get();
            }
            else if(cm_Faculties.SelectedIndex >= 0)
            {
                
                int? profManage = null;
                if(cm_Professor.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_Professor.SelectedValue);
                }
                //For Update Entities (IdDepartment,NameDepartment,IdFacultie,IsDeleted)
                await implementDepartment.Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text,Convert.ToInt32(cm_Faculties.SelectedValue), profManage, false);
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
