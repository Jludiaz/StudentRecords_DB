namespace WinFormsApp1
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
            button_logout = new Button();
            SuspendLayout();
            // 
            // button_logout
            // 
            button_logout.Location = new Point(361, 199);
            button_logout.Name = "button_logout";
            button_logout.Size = new Size(75, 23);
            button_logout.TabIndex = 0;
            button_logout.Text = "Logout";
            button_logout.UseVisualStyleBackColor = true;
            button_logout.Click += button_logout_Click;
            // 
            // Form_main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_logout);
            Name = "Form_main";
            Text = "Form_main";
            Load += Form_main_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_logout;
    }
}