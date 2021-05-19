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
    public partial class frm_Department : Form
    {
        ImplementDepartment implementDepartment;
        public frm_Department()
        {
            InitializeComponent();
            implementDepartment = new ImplementDepartment();
        }
        void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var getListFacultie = work.Facultie.AllNotDeleted().Select(f => new { f.Id, f.Name}).ToList();
                var getListProfessor = work.Professor.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var getDepartment = work.Department.AllNotDeleted()
                    .Select(f => new {
                        f.Id,
                        f.Name,
                        NameFacultie = (f.FacultieId == null) ? null : f.Facultie.Name,
                        NameProfessor = (f.ProfessorManageId == null) ? null : f.ProfessorManage.Name
                    }).ToList();

                if (getListFacultie.Count > 0)
                {
                    cm_Faculties.DataSource = getListFacultie;
                    cm_Faculties.DisplayMember = "Name";
                    cm_Faculties.ValueMember = "Id";
                    cm_Faculties.SelectedIndex = -1;
                }
                if (getListProfessor.Count > 0)
                {
                    cm_Professor.DataSource = getListProfessor;
                    cm_Professor.DisplayMember = "Name";
                    cm_Professor.ValueMember = "Id";
                    cm_Professor.SelectedIndex = -1;
                }

                GvResult.DataSource = getDepartment.ToList();
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {

                var getListFacultie = work.Facultie.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var getListProfessor = work.Professor.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var getDepartment = work.Department.GetByName(_Name)
                    .Select(f => new {
                        f.Id,
                        f.Name,
                        NameFuc = f.Facultie.Name,
                        NameProf = (f.ProfessorManageId == null) ? null : f.ProfessorManage.Name
                    }).ToList();
                GvResult.DataSource = getDepartment.ToList();
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
                var nameDepartment = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var idDepartment = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {nameDepartment}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Delete Entities (IdDepartment,NameDepartment,IdFaculties,IsDeleted = true) for visable from my project Not my database
                    implementDepartment.Deleted(Convert.ToInt32(idDepartment), nameDepartment, true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_Id.Text) && cm_Faculties.SelectedIndex >= 0)
            {
                
                int? profManage = null;
                if (cm_Professor.SelectedIndex >= 0)
                {
                    profManage = Convert.ToInt32(cm_Professor.SelectedValue);
                }
                //For Add Entities (IdDepartment auto No Bas,NameDepartment,IdFacultie)
                implementDepartment.Add(txt_Name.Text, Convert.ToInt32(cm_Faculties.SelectedValue), profManage);
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
                implementDepartment.Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text,Convert.ToInt32(cm_Faculties.SelectedValue), profManage, false);
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
