namespace WinFormsApp1
{
    partial class Form_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_username = new TextBox();
            textBox_password = new TextBox();
            label_username = new Label();
            label_password = new Label();
            button_login = new Button();
            SuspendLayout();
            // 
            // textBox_username
            // 
            textBox_username.Location = new Point(385, 179);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(100, 23);
            textBox_username.TabIndex = 0;
            textBox_username.TextChanged += textBox_username_TextChanged;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(385, 220);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(100, 23);
            textBox_password.TabIndex = 1;
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Location = new Point(319, 182);
            label_username.Name = "label_username";
            label_username.Size = new Size(60, 15);
            label_username.TabIndex = 2;
            label_username.Text = "Username";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Location = new Point(319, 223);
            label_password.Name = "label_password";
            label_password.Size = new Size(57, 15);
            label_password.TabIndex = 3;
            label_password.Text = "Password";
            // 
            // button_login
            // 
            button_login.Location = new Point(396, 269);
            button_login.Name = "button_login";
            button_login.Size = new Size(75, 23);
            button_login.TabIndex = 4;
            button_login.Text = "Log-in";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // Form_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_login);
            Controls.Add(label_password);
            Controls.Add(label_username);
            Controls.Add(textBox_password);
            Controls.Add(textBox_username);
            Name = "Form_login";
            RightToLeft = RightToLeft.No;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_username;
        private TextBox textBox_password;
        private Label label_username;
        private Label label_password;
        private Button button_login;
    }
}
