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

        public frm_Professor()
        {
            InitializeComponent();
        }


        void Updated(int _Idprofessor, string _NameDepartment, int _IdDepartment, int? _IdManager, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var department = work.Department.GetId(_IdDepartment);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Professor.Update(new Professor
                {
                    Id = _Idprofessor,
                    Name = _NameDepartment,
                    Department = department,
                    ProfessorManage = professor,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        void Deleted(int _IdDepartment, string _NameProfessor, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Professor.Update(new Professor
                {
                    Id = _IdDepartment,
                    Name = _NameProfessor,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        void Add(string _NameProfessor, int _IdDepartment, int? _IdManager)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var department = work.Department.GetId(_IdDepartment);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Professor.Add(new Professor { Name = _NameProfessor, Department = department, ProfessorManage = professor });

                work.Commet();
            }

        }
        void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var getListDepartment = work.Department.AllNotDeleted().Select(d => new { d.Id, d.Name }).ToList();
                var getListProfessorManage = work.Professor.AllNotDeleted().Select(d => new { d.Id, d.Name }).ToList();
                var getListProfessor = work.Professor.AllNotDeleted()
                    .Select(f => new {
                        f.Id,
                        f.Name,
                        NameDepartment = f.DepartmentsId != null ? f.Department.Name:null ,
                        NameProfessorfManage = f.ProfessorManageId != null ? f.ProfessorManage.Name:null
                    }).ToList();


                GvResult.DataSource = getListProfessor;

                if (getListDepartment.Count > 0)
                {
                    cm_Department.DataSource = getListDepartment;
                    cm_Department.DisplayMember = "Name";
                    cm_Department.ValueMember = "Id";
                    cm_Department.SelectedIndex = -1;
                }
                if (getListProfessorManage.Count > 0)
                {
                    cm_ProfessorManage.DataSource = getListProfessorManage;
                    cm_ProfessorManage.DisplayMember = "Name";
                    cm_ProfessorManage.ValueMember = "Id";
                    cm_ProfessorManage.SelectedIndex = -1;
                }
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var getListDepartment = work.Department.AllNotDeleted().Select(d => new { d.Id, d.Name }).ToList();
                var getListProfessorManage = work.Professor.AllNotDeleted().Select(d => new { d.Id, d.Name }).ToList();
                var getListProfessor = work.Professor.GetByName(_Name)
                    .Select(f => new {
                        f.Id,
                        f.Name,
                        NameDep = f.Department.Name,
                        NameProfManage = (f.ProfessorManageId == null) ? null : f.ProfessorManage.Name
                    }).ToList(); ;
                GvResult.DataSource = getListProfessor;

                if (getListDepartment.Count > 0)
                {
                    cm_Department.DataSource = getListDepartment;
                    cm_Department.DisplayMember = "Name";
                    cm_Department.ValueMember = "Id";
                    cm_Department.SelectedIndex = -1;
                }
                if (getListProfessorManage.Count > 0)
                {
                    cm_ProfessorManage.DataSource = getListProfessorManage;
                    cm_ProfessorManage.DisplayMember = "Name";
                    cm_ProfessorManage.ValueMember = "Id";
                    cm_ProfessorManage.SelectedIndex = -1;
                }
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
                var nameFaculties = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var idFaculties = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {nameFaculties}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Update Entities (Id,Name,IsDeleted = true) for visable from my project Not my database
                    Deleted(Convert.ToInt32(idFaculties), nameFaculties, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text) && cm_Department.SelectedIndex >= 0)
            {

                int? profManage = null;
                if (cm_ProfessorManage.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_ProfessorManage.SelectedValue);
                }
                //For Add Entities (IdDepartment auto No Bas,NameDepartment,IdFacultie)
                Add(txt_Name.Text, Convert.ToInt32(cm_Department.SelectedValue), profManage);
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
                Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text, Convert.ToInt32(cm_Department.SelectedValue), profManage, false);
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
