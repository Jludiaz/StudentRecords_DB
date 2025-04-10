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

        private void button_deleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?\n\nThis will delete ALL information related to this user across all tables.\nThis action cannot be undone.",
                "Confirm User Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlTransaction transaction = con.BeginTransaction();

                        try
                        {
                            // First, get the student's GWID since that's used as a foreign key in other tables
                            SqlCommand getGwidCmd = new SqlCommand(
                                "SELECT gwid FROM Students WHERE email = @email", con, transaction);
                            getGwidCmd.Parameters.AddWithValue("@email", userEmail);

                            var gwid = getGwidCmd.ExecuteScalar();

                            if (gwid != null)
                            { 
                                // Delete from Taking table
                                SqlCommand deleteTakingCmd = new SqlCommand(
                                    "DELETE FROM Taking WHERE gwid = @gwid", con, transaction);
                                deleteTakingCmd.Parameters.AddWithValue("@gwid", gwid);
                                deleteTakingCmd.ExecuteNonQuery();

                                // Delete from Payments table (if it exists and has a relationship to Students)
                                SqlCommand deletePaymentsCmd = new SqlCommand(
                                    "DELETE FROM Payments WHERE gwid = @gwid", con, transaction);
                                deletePaymentsCmd.Parameters.AddWithValue("@gwid", gwid);
                                deletePaymentsCmd.ExecuteNonQuery();

                                // Delete from MustPay table (if it exists and has a relationship to Students)
                                SqlCommand deleteMustPayCmd = new SqlCommand(
                                    "DELETE FROM MustPay WHERE gwid = @gwid", con, transaction);
                                deleteMustPayCmd.Parameters.AddWithValue("@gwid", gwid);
                                deleteMustPayCmd.ExecuteNonQuery();

                                // Delete from Has table (if it exists and has a relationship to Students)
                                SqlCommand deleteHasCmd = new SqlCommand(
                                    "DELETE FROM Has WHERE gwid = @gwid", con, transaction);
                                deleteHasCmd.Parameters.AddWithValue("@gwid", gwid);
                                deleteHasCmd.ExecuteNonQuery();

                                // Delete from IsA table (if it exists and has a relationship to Students)
                                SqlCommand deleteIsACmd = new SqlCommand(
                                    "DELETE FROM IsA WHERE gwid = @gwid", con, transaction);
                                deleteIsACmd.Parameters.AddWithValue("@gwid", gwid);
                                deleteIsACmd.ExecuteNonQuery();

                                // Finally, delete from Students table
                                SqlCommand deleteStudentCmd = new SqlCommand(
                                    "DELETE FROM Students WHERE gwid = @gwid", con, transaction);
                                deleteStudentCmd.Parameters.AddWithValue("@gwid", gwid);
                                deleteStudentCmd.ExecuteNonQuery();

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("User has been successfully deleted from all tables.",
                                    "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Hide();
                                Form_login loginForm = new Form_login();
                                loginForm.Show();
                            }
                        }
                        catch (Exception ex)
                        {
                            // If anything goes wrong, roll back the transaction
                            transaction.Rollback();
                            throw ex; // Re-throw to be caught by outer catch
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







    }
}