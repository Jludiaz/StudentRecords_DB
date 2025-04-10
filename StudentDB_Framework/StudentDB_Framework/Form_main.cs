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
    public partial class Form_main : Form
    {
        private string userEmail; // Store the logged-in user's email

        // Constructor with email parameter - used when coming from login
        public Form_main(string email)
        {
            InitializeComponent();
            userEmail = email; // Store the email
        }

        // Default constructor - needed for designer support
        public Form_main()
        {
            InitializeComponent();
        }

        // Form load event - loads data for the logged-in user
        private void Form_main_Load_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                LoadStudentData();
            }
            else
            {
                // If no email provided (shouldn't happen in normal flow), show all students
                this.studentsTableAdapter.Fill(this.studentDBDataSet.Students);
            }
        }

        // Load student data for the specific logged-in user
        private void LoadStudentData()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Students WHERE email = @email";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", userEmail);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Unbind the existing source and set the new filtered data
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        // Logout button click event
        private void button_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Hide this form
                this.Hide();

                // Create and show the login form
                Form_login fl = new Form_login(); // Assuming login form is named Form1 now
                fl.Show();
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}