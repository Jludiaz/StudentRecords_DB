using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDB_Framework
{
    public partial class form_user : Form
    {
        private string userEmail;

        // Constructor with email parameter
        public form_user(string email)
        {
            InitializeComponent();
            userEmail = email;
        }

        // Default constructor for the designer
        public form_user()
        {
            InitializeComponent();
        }

        private void form_user_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                LoadUserInformation();
            }
            else
            {
                MessageBox.Show("No email provided. Cannot load user information.");
            }
        }

        private void LoadUserInformation()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Use the exact same query format that worked in Form_main
                    string query = @"SELECT s.* 
                           FROM Students s
                           WHERE s.email = @email";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", userEmail);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Make sure to set to null first to clear any previous binding
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user information: " + ex.Message);
            }
        }

        private void buttonmain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_main mainForm = new Form_main(userEmail);
            mainForm.Show();
        }

        private void buttonlogout_Click(object sender, EventArgs e)
        {
            // Logout to login form
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form_login loginForm = new Form_login();
                loginForm.Show();
            }
        }
    }
}