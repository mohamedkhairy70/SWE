
namespace SWE.UI.Forms
{
    partial class frm_Department
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cm_Professor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cm_Faculties = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GvResult = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameFacultie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameProfessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cm_Professor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cm_Faculties);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_Id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 225);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "رئيس القسم";
            // 
            // cm_Professor
            // 
            this.cm_Professor.FormattingEnabled = true;
            this.cm_Professor.Location = new System.Drawing.Point(279, 109);
            this.cm_Professor.Name = "cm_Professor";
            this.cm_Professor.Size = new System.Drawing.Size(261, 27);
            this.cm_Professor.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "الكلية";
            // 
            // cm_Faculties
            // 
            this.cm_Faculties.FormattingEnabled = true;
            this.cm_Faculties.Location = new System.Drawing.Point(279, 76);
            this.cm_Faculties.Name = "cm_Faculties";
            this.cm_Faculties.Size = new System.Drawing.Size(261, 27);
            this.cm_Faculties.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 44);
            this.button3.TabIndex = 6;
            this.button3.Text = "بحث";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "معرف القسم";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(279, 12);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.ReadOnly = true;
            this.txt_Id.Size = new System.Drawing.Size(261, 26);
            this.txt_Id.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "اسم القسم";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "حفظ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "جدبد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(279, 44);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(261, 26);
            this.txt_Name.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GvResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 353);
            this.panel2.TabIndex = 1;
            // 
            // GvResult
            // 
            this.GvResult.AllowUserToAddRows = false;
            this.GvResult.AllowUserToDeleteRows = false;
            this.GvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.NameFacultie,
            this.NameProfessor,
            this.Edit,
            this.Delete});
            this.GvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvResult.Location = new System.Drawing.Point(0, 0);
            this.GvResult.Name = "GvResult";
            this.GvResult.ReadOnly = true;
            this.GvResult.RowTemplate.Height = 25;
            this.GvResult.Size = new System.Drawing.Size(899, 353);
            this.GvResult.TabIndex = 0;
            this.GvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "معرف القسم";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "اسم  القسم";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // NameFacultie
            // 
            this.NameFacultie.DataPropertyName = "NameFacultie";
            this.NameFacultie.HeaderText = "اسم الكلية";
            this.NameFacultie.Name = "NameFacultie";
            this.NameFacultie.ReadOnly = true;
            // 
            // NameProfessor
            // 
            this.NameProfessor.DataPropertyName = "NameProfessor";
            this.NameProfessor.HeaderText = "رئيس القسم";
            this.NameProfessor.Name = "NameProfessor";
            this.NameProfessor.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "تعديل";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Text = "تعديل";
            this.Edit.ToolTipText = "تعديل";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "الحذف";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Text = "الحذف";
            this.Delete.ToolTipText = "الحذف";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // frm_Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اقسام الكليات";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GvResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cm_Faculties;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cm_Professor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameFacultie;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProfessor;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}