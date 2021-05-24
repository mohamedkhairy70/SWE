using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWE.UI.Forms
{
    public partial class frm_Student : Form
    {
        ImplementForms.ImplementStudent implementStudent;
        public frm_Student()
        {
            InitializeComponent();
            implementStudent = new ImplementForms.ImplementStudent();
        }
        void ClearData()
        {
            txt_FullName.Clear();
            txt_Address.Clear();
            txt_Leval.Clear();
            txt_Phone.Clear();
            BDate.Value = DateTime.Now;
            txt_Id.Clear();
            txt_UserName.Clear();
            txt_Paassword.Clear();
            txt_UserName.ReadOnly = false;
        }
        async void get()
        {
            using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
            {
                var getListStudent = await work.Student.AllNotDeleted();

                var StudentResult = getListStudent.Select
                                        (u => new
                                        {
                                            u.Id,
                                            u.FullName,
                                            u.Address,
                                            u.Leval,
                                            u.Phone,
                                            u.BDate,
                                            UserName = u.StudentLog.UserName
                                        }).ToList();

                GvResult.DataSource = StudentResult;

            }
            ClearData();
        }
        async Task<bool> checkUserNameIsExists(string userName)
        {
            var factory = new SWEContextFactory();
            using var context = factory.CreateDbContext();
            using (var work = new UnitOfWork(context))
            {
                return await work.StudentLog.UserExsists(userName);
            }

        }
        async void getByName(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
            {

                var getListStudent = await work.Student.GetByName(_Name);

                var StudentResult = getListStudent.Select
                                        (u => new
                                        {
                                            u.Id,
                                            u.FullName,
                                            u.Address,
                                            u.Leval,
                                            u.Phone,
                                            u.BDate,
                                            UserName = u.StudentLog.UserName
                                        }).ToList();

                GvResult.DataSource = StudentResult;

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
                var GVCellsOfRow = GvResult.Rows[e.RowIndex];
                txt_Id.Text = GVCellsOfRow.Cells["Id"].Value.ToString();
                txt_FullName.Text = GVCellsOfRow.Cells["FullName"].Value.ToString();
                txt_Address.Text = GVCellsOfRow.Cells["Address"].Value.ToString();
                txt_Leval.Text = GVCellsOfRow.Cells["Leval"].Value.ToString();
                txt_Phone.Text = GVCellsOfRow.Cells["Phone"].Value.ToString();
                BDate.Text = GVCellsOfRow.Cells["UBDate"].Value.ToString();
                txt_UserName.Text = GVCellsOfRow.Cells["UserName"].Value.ToString();
                txt_UserName.ReadOnly = true;
            }
            if (GvResult.Columns[e.ColumnIndex].Name == "Delete")
            {
                var namestudent = GvResult.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                var idstudent = GvResult.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var msg = MessageBox.Show($"هل انت متأكد بأنك تريد حذف ... {namestudent}", "رسالة حذف"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    //For Update Entities (Id,Name,IsDeleted = true) for visable from my project Not my database
                    await implementStudent.Deleted(Convert.ToInt32(idstudent), namestudent,true);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Id.Text))
            {

                var studentLog = new StudentLog { UserName = txt_UserName.Text };
                if (await checkUserNameIsExists(studentLog.UserName))
                { MessageBox.Show("يوجد أسم مستخدم موجود بنفس الاسم برجاء اختيار اسم اخر"); return; }
                
                var student = new Student
                {
                    FullName = txt_FullName.Text,
                    Address = txt_Address.Text,
                    Leval = txt_Leval.Text,
                    Phone = txt_Phone.Text,
                    BDate = BDate.Value,
                };
                await implementStudent.Add(student,studentLog,txt_Paassword.Text);
                //For Get All Data and Clear Data
                get();
            }
            else
            {
                var studentLog = new StudentLog { UserName = txt_UserName.Text };
                if (await checkUserNameIsExists(studentLog.UserName))
                {
                    var student = new Student
                    {
                        Id = Convert.ToInt32(txt_Id.Text),
                        FullName = txt_FullName.Text,
                        Address = txt_Address.Text,
                        Leval = txt_Leval.Text,
                        Phone = txt_Phone.Text,
                        BDate = BDate.Value
                    };
                    await implementStudent.Updated(student, studentLog, txt_Paassword.Text);
                    //For Get All Data and Clear Data
                    get();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //For Get Data By Name and Clear Data
            if(!string.IsNullOrEmpty(txt_FullName.Text))
                getByName(txt_FullName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //For Get Data and Clear Data
            get();
        }
    }
}
