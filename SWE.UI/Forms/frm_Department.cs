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

        
        void Updated(int _IdDepartment, string _NameDepartment, int IdFacultie,int? IdManager, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var facultie = work.Facultie.GetId(IdFacultie);
                var professor = (IdManager == null)?null:work.Professor.GetId(IdManager);
                work.Department.Update(new Department { Id = _IdDepartment, Name = _NameDepartment,
                    Facultie = facultie,ProfessorManage = professor, IsDelete = _IsDelete });

                work.Commet();
            }

        }
        void Deleted(int _IdDepartment, string _NameDepartment, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Department.Update(new Department
                {
                    Id = _IdDepartment,
                    Name = _NameDepartment,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        void Add(string _NameDepartment, int IdFacultie, int? IdManager)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var facultie = work.Facultie.GetId(IdFacultie);
                var professor = (IdManager == null) ? null : work.Professor.GetId(IdManager);
                work.Department.Add(new Department { Name = _NameDepartment, Facultie = facultie,ProfessorManage = professor });

                work.Commet();
            }
            
        }
        void get()
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var GetFuc = work.Facultie.AllNotDeleted().Select(f => new { f.Id, f.Name}).ToList();
                var GetProf = work.Professor.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var GetDepartment = work.Department.AllNotDeleted()
                    .Select(f => new { f.Id, f.Name, NameFuc = GetFuc.Find(x=>x.Id== f.FacultieId).Name
                        ,NameProf = GetProf.Find(x => x.Id == f.ProfessorManageId)}).ToList();

                //var JoinDepartment = from dep in GetDepartment
                //                     join fuc in GetFuc on dep.FacultieId equals fuc.Id
                //                     join prof in GetProf on dep.ProfessorManageId equals prof.Id
                //                     select new
                //                     {
                //                         dep.Id,
                //                         dep.Name,
                //                         NameFuc = fuc.Name,
                //                         ProfName = prof.Name
                //                     };

                if (GetFuc.Count > 0)
                {
                    cm_Faculties.DataSource = GetFuc;
                    cm_Faculties.DisplayMember = "Name";
                    cm_Faculties.ValueMember = "Id";
                    cm_Faculties.SelectedIndex = -1;
                }
                if (GetProf.Count > 0)
                {
                    cm_Professor.DataSource = GetProf;
                    cm_Professor.DisplayMember = "Name";
                    cm_Professor.ValueMember = "Id";
                    cm_Professor.SelectedIndex = -1;
                }

                GvResult.DataSource = GetDepartment.ToList();
            }
            txt_Id.Clear();
            txt_Name.Clear();
        }
        void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {

                var GetFuc = work.Facultie.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var GetProf = work.Professor.AllNotDeleted().Select(f => new { f.Id, f.Name }).ToList();
                var GetDepartment = work.Department.GetByName(_Name)
                    .Select(f => new {
                        f.Id,
                        f.Name,
                        NameFuc = GetFuc.Find(x => x.Id == f.FacultieId).Name,
                        NameProf = GetProf.Find(x => x.Id == f.ProfessorManageId)
                    }).ToList();

                if (GetFuc.Count > 0)
                {
                    cm_Faculties.DataSource = GetFuc;
                    cm_Faculties.DisplayMember = "Name";
                    cm_Faculties.ValueMember = "Id";
                    cm_Faculties.SelectedIndex = -1;
                }
                if (GetProf.Count > 0)
                {
                    cm_Professor.DataSource = GetProf;
                    cm_Professor.DisplayMember = "Name";
                    cm_Professor.ValueMember = "Id";
                    cm_Professor.SelectedIndex = -1;
                }
                GvResult.DataSource = GetDepartment.ToList();
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
                var NameDepartment = GvResult.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var IdDepartment = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {NameDepartment}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Delete Entities (IdDepartment,NameDepartment,IdFaculties,IsDeleted = true) for visable from my project Not my database
                    Deleted(Convert.ToInt32(IdDepartment), NameDepartment, true);
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
                Add(txt_Name.Text, Convert.ToInt32(cm_Faculties.SelectedValue), profManage);
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
                Updated(Convert.ToInt32(txt_Id.Text), txt_Name.Text,Convert.ToInt32(cm_Faculties.SelectedValue), profManage, false);
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
