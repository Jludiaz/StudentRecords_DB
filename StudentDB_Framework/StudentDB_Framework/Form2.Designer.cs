namespace StudentDB_Framework
{
    partial class form_user
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_main = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_deleteUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(654, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // button_main
            // 
            this.button_main.Location = new System.Drawing.Point(12, 12);
            this.button_main.Name = "button_main";
            this.button_main.Size = new System.Drawing.Size(95, 23);
            this.button_main.TabIndex = 1;
            this.button_main.Text = "Back To Main";
            this.button_main.UseVisualStyleBackColor = true;
            this.button_main.Click += new System.EventHandler(this.buttonmain_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(693, 12);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(95, 23);
            this.button_logout.TabIndex = 2;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.buttonlogout_Click);
            // 
            // button_deleteUser
            // 
            this.button_deleteUser.Location = new System.Drawing.Point(12, 415);
            this.button_deleteUser.Name = "button_deleteUser";
            this.button_deleteUser.Size = new System.Drawing.Size(119, 23);
            this.button_deleteUser.TabIndex = 3;
            this.button_deleteUser.Text = "Delete User";
            this.button_deleteUser.UseVisualStyleBackColor = true;
            this.button_deleteUser.Click += new System.EventHandler(this.button_deleteUser_Click);
            // 
            // form_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_deleteUser);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_main);
            this.Controls.Add(this.dataGridView1);
            this.Name = "form_user";
            this.Text = "UserInformation";
            this.Load += new System.EventHandler(this.form_user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_main;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_deleteUser;
    }
}