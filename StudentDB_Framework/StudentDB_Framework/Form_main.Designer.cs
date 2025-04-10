using System.Drawing;
using System.Windows.Forms;

namespace StudentDB_Framework
{
    partial class Form_main
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
            this.components = new System.ComponentModel.Container();
            this.button_logout = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.studentDBDataSet = new StudentDB_Framework.StudentDBDataSet();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new StudentDB_Framework.StudentDBDataSetTableAdapters.StudentsTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentDBDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gwidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(12, 12);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(64, 20);
            this.button_logout.TabIndex = 0;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // studentDBDataSet
            // 
            this.studentDBDataSet.DataSetName = "StudentDBDataSet";
            this.studentDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.studentDBDataSet;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gwidDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.firstDataGridViewTextBoxColumn,
            this.lastDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.studentsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(91, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 271);
            this.dataGridView1.TabIndex = 2;
            // 
            // studentDBDataSetBindingSource
            // 
            this.studentDBDataSetBindingSource.DataSource = this.studentDBDataSet;
            this.studentDBDataSetBindingSource.Position = 0;
            // 
            // studentDBDataSetBindingSource1
            // 
            this.studentDBDataSetBindingSource1.DataSource = this.studentDBDataSet;
            this.studentDBDataSetBindingSource1.Position = 0;
            // 
            // gwidDataGridViewTextBoxColumn
            // 
            this.gwidDataGridViewTextBoxColumn.DataPropertyName = "gwid";
            this.gwidDataGridViewTextBoxColumn.HeaderText = "gwid";
            this.gwidDataGridViewTextBoxColumn.Name = "gwidDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // firstDataGridViewTextBoxColumn
            // 
            this.firstDataGridViewTextBoxColumn.DataPropertyName = "first";
            this.firstDataGridViewTextBoxColumn.HeaderText = "first";
            this.firstDataGridViewTextBoxColumn.Name = "firstDataGridViewTextBoxColumn";
            // 
            // lastDataGridViewTextBoxColumn
            // 
            this.lastDataGridViewTextBoxColumn.DataPropertyName = "last";
            this.lastDataGridViewTextBoxColumn.HeaderText = "last";
            this.lastDataGridViewTextBoxColumn.Name = "lastDataGridViewTextBoxColumn";
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "gender";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_logout);
            this.Name = "Form_main";
            this.Text = "Form_main";
            this.Load += new System.EventHandler(this.Form_main_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDBDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_logout;
        private TextBox textBox1;
        private StudentDBDataSet studentDBDataSet;
        private BindingSource studentsBindingSource;
        private StudentDBDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn gwidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private BindingSource studentDBDataSetBindingSource;
        private BindingSource studentDBDataSetBindingSource1;
    }
}