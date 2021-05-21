using SWE.UI.ImplementForms;
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
    public partial class frm_Professor : Form
    {
        ImplementProfessor implementProfessor;
        public frm_Professor()
        {
            InitializeComponent();
            implementProfessor = new ImplementProfessor();
        }

        async void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var getAwaitListDepartment = await work.Department.AllNotDeleted();
                var getAwaitListProfessorManage = await work.Professor.AllNotDeleted();
                var getAwaitListProfessor = await work.Professor.AllNotDeleted();
                    

                var DepartmentResult = getAwaitListDepartment.Select(d => new { d.Id, d.Name }).ToList();
                var ProfessorManageResult = getAwaitListProfessorManage.Select(d => new { d.Id, d.Name }).ToList();
                var ProfessorResult = getAwaitListProfessor.Select(f => new {
                                        f.Id,
                                        f.Name,
                                        NameDepartment = f.DepartmentsId != null ? f.Department.Name : null,
                                        NameProfessorfManage = f.ProfessorManageId != null ? f.ProfessorManage.Name : null
                                    }).ToList();


                GvResult.DataSource = ProfessorResult;

                if (DepartmentResult.Count > 0)
                {
                    cm_Department.DataSource = DepartmentResult;
                    cm_Department.DisplayMember = "Name";
                    cm_Department.ValueMember = "Id";
                    cm_Department.SelectedIndex = -1;
                }
                if (ProfessorManageResult.Count > 0)
                {
                    cm_ProfessorManage.DataSource = ProfessorManageResult;
                    cm_ProfessorManage.DisplayMember = "Name";
                    cm_ProfessorManage.ValueMember = "Id";
                    cm_ProfessorManage.SelectedIndex = -1;
                }
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        async void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {

                var getAwaitListProfessor = await work.Professor.GetByName(_Name);
                var ProfessorResult = getAwaitListProfessor.Select(f => new {
                    f.Id,
                    f.Name,
                    NameDepartment = f.DepartmentsId != null ? f.Department.Name : null,
                    NameProfessorfManage = f.ProfessorManageId != null ? f.ProfessorManage.Name : null
                }).ToList();


                GvResult.DataSource = ProfessorResult;
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
                var nameFaculties = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var idFaculties = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {nameFaculties}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Update Entities (Id,Name,IsDeleted = true) for visable from my project Not my database
                    await implementProfessor.Deleted(Convert.ToInt32(idFaculties), nameFaculties, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text) && cm_Department.SelectedIndex >= 0)
            {

                int? profManage = null;
                if (cm_ProfessorManage.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_ProfessorManage.SelectedValue);
                }
                //For Add Entities (IdDepartment auto No Bas,NameDepartment,IdFacultie)
                await implementProfessor.Add(txt_Name.Text, Convert.ToInt32(cm_Department.SelectedValue), profManage);
                //For Get All Data and Clear Data
                get();
            }
            else if (cm_Department.SelectedIndex >= 0)
            {

                int? profManage = null;
                if (cm_ProfessorManage.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_ProfessorManage.SelectedValue);
                }
                //For Update Entities (IdDepartment,NameDepartment,IdFacultie,IsDeleted)
                await implementProfessor.Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text, Convert.ToInt32(cm_Department.SelectedValue), profManage, false);
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
