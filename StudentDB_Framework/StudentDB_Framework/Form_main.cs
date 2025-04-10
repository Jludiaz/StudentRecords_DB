using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentDB_Framework
{
    public partial class Form_main : Form
    {
        private string userEmail; //store the user email, make it private for security

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
        private void Form_main_Load_1(object sender, EventArgs e)
        {
            LoadStudentGrades(); //Call our two functions 
            CalculateAndDisplayGradeStats();
        }

        //So this function will make a db connection like we learned in lab 6 and we display a query showing classes
        //This query is pulled directly from our queries that we made
        private void LoadStudentGrades()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Query to get student grades with course names
                    string query = @"SELECT s.first, s.last, c.name AS course_name, t.grade
                           FROM Students s
                           JOIN Taking t ON s.gwid = t.gwid
                           JOIN Courses c ON t.crn = c.crn
                           WHERE s.email = @email";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    // This is making a table in C#
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grades: " + ex.Message);
            }
        }

        //THis function does the same thing as above essentially but we are getting grade statistics
        private void CalculateAndDisplayGradeStats()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // MAX
                    string maxQuery = @"SELECT MAX(CAST(grade AS FLOAT)) 
                                      FROM Students s
                                      JOIN Taking t ON s.gwid = t.gwid
                                      WHERE s.email = @email";

                    SqlCommand maxCmd = new SqlCommand(maxQuery, con);
                    maxCmd.Parameters.AddWithValue("@email", userEmail);
                    object maxResult = maxCmd.ExecuteScalar();

                    // MIN
                    string minQuery = @"SELECT MIN(CAST(grade AS FLOAT)) 
                                      FROM Students s
                                      JOIN Taking t ON s.gwid = t.gwid
                                      WHERE s.email = @email";

                    SqlCommand minCmd = new SqlCommand(minQuery, con);
                    minCmd.Parameters.AddWithValue("@email", userEmail);
                    object minResult = minCmd.ExecuteScalar();

                    // AVG
                    string avgQuery = @"SELECT AVG(CAST(grade AS FLOAT)) 
                                      FROM Students s
                                      JOIN Taking t ON s.gwid = t.gwid
                                      WHERE s.email = @email";

                    SqlCommand avgCmd = new SqlCommand(avgQuery, con);
                    avgCmd.Parameters.AddWithValue("@email", userEmail);
                    object avgResult = avgCmd.ExecuteScalar();

                    // Display results in labels
                    if (maxResult != DBNull.Value && maxResult != null)
                        label6.Text = Convert.ToDouble(maxResult).ToString("F2");
                    else
                        label6.Text = "N/A";

                    if (minResult != DBNull.Value && minResult != null)
                        label7.Text = Convert.ToDouble(minResult).ToString("F2");
                    else
                        label7.Text = "N/A";

                    if (avgResult != DBNull.Value && avgResult != null)
                        label8.Text = Convert.ToDouble(avgResult).ToString("F2");
                    else
                        label8.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating grade statistics: " + ex.Message);
                label6.Text = "Error";
                label7.Text = "Error";
                label8.Text = "Error";
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form_login fl = new Form_login();
                fl.Show();
            }
        }

        // Making a textbox that can search
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text.Trim().ToLower();

            try
            {
                // If search box is empty, show all grades
                if (string.IsNullOrEmpty(value))
                {
                    LoadStudentGrades();
                    return;
                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Query that filters courses by the search term
                    string query = @"SELECT s.first, s.last, c.name AS course_name, t.grade
                                  FROM Students s
                                  JOIN Taking t ON s.gwid = t.gwid
                                  JOIN Courses c ON t.crn = c.crn
                                  WHERE s.email = @email 
                                  AND (LOWER(c.name) LIKE @search OR CAST(c.crn AS VARCHAR) LIKE @search)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    cmd.Parameters.AddWithValue("@search", "%" + value + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }
        // Simple form hide that takes us to our user information form
        private void button_userinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_user userForm = new form_user(userEmail);
            userForm.Show();
        }
    }
}