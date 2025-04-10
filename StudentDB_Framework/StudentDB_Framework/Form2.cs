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
		private Button button_editFirstName;

		// Constructor with email parameter
		public form_user(string email)
		{
			InitializeComponent();
			userEmail = email;

			// Create and set up the edit button
			button_editFirstName = new Button();
			button_editFirstName.Text = "Edit First Name";
			button_editFirstName.Size = new Size(120, 30);
			button_editFirstName.Location = new Point(12, 250); // Adjust location as needed
			button_editFirstName.Click += new EventHandler(button_editFirstName_Click);
			this.Controls.Add(button_editFirstName);

			// Set up double-click event for the DataGridView
			dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

				// Add instruction label
				Label lblInstructions = new Label();
				lblInstructions.Text = "Double-click on first name to edit or select a row and click the Edit button";
				lblInstructions.AutoSize = true;
				lblInstructions.Location = new Point(12, 225);
				this.Controls.Add(lblInstructions);
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

					string query = @"SELECT s.* FROM Students s WHERE s.email = @email";

					SqlCommand cmd = new SqlCommand(query, con);
					cmd.Parameters.AddWithValue("@email", userEmail);

					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					adapter.Fill(dt);

					dataGridView1.DataSource = null;
					dataGridView1.DataSource = dt;

					// Make the first name column visually distinct (optional)
					if (dataGridView1.Columns.Contains("first"))
					{
						dataGridView1.Columns["first"].DefaultCellStyle.BackColor = Color.LightYellow;
						dataGridView1.Columns["first"].HeaderText = "First Name (Editable)";
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading user information: " + ex.Message);
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Find the first name column index
			int firstNameColumnIndex = -1;
			for (int i = 0; i < dataGridView1.Columns.Count; i++)
			{
				if (dataGridView1.Columns[i].Name.Equals("first", StringComparison.OrdinalIgnoreCase))
				{
					firstNameColumnIndex = i;
					break;
				}
			}

			// Check if a valid row is clicked and it's the first name column
			if (e.RowIndex >= 0 && e.ColumnIndex == firstNameColumnIndex)
			{
				EditFirstName();
			}
		}

		private void button_editFirstName_Click(object sender, EventArgs e)
		{
			EditFirstName();
		}

		private void EditFirstName()
		{
			try
			{
				// Check if a row is selected
				if (dataGridView1.SelectedRows.Count > 0)
				{
					// Find the first name column
					int firstNameColumnIndex = -1;
					for (int i = 0; i < dataGridView1.Columns.Count; i++)
					{
						if (dataGridView1.Columns[i].Name.Equals("first", StringComparison.OrdinalIgnoreCase))
						{
							firstNameColumnIndex = i;
							break;
						}
					}

					if (firstNameColumnIndex >= 0)
					{
						// Get the current value
						string currentFirstName = dataGridView1.SelectedRows[0].Cells[firstNameColumnIndex].Value.ToString();

						// Prompt user for new value - using Windows Forms dialog since Interaction.InputBox requires Microsoft.VisualBasic reference
						Form inputForm = new Form();
						inputForm.Width = 300;
						inputForm.Height = 150;
						inputForm.Text = "Edit First Name";
						inputForm.StartPosition = FormStartPosition.CenterParent;
						inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
						inputForm.MaximizeBox = false;

						Label label = new Label();
						label.Text = "New First Name:";
						label.Location = new Point(10, 20);
						label.Width = 100;

						TextBox textBox = new TextBox();
						textBox.Location = new Point(120, 20);
						textBox.Width = 150;
						textBox.Text = currentFirstName;

						Button okButton = new Button();
						okButton.Text = "OK";
						okButton.DialogResult = DialogResult.OK;
						okButton.Location = new Point(120, 70);

						Button cancelButton = new Button();
						cancelButton.Text = "Cancel";
						cancelButton.DialogResult = DialogResult.Cancel;
						cancelButton.Location = new Point(200, 70);

						inputForm.Controls.Add(label);
						inputForm.Controls.Add(textBox);
						inputForm.Controls.Add(okButton);
						inputForm.Controls.Add(cancelButton);
						inputForm.AcceptButton = okButton;
						inputForm.CancelButton = cancelButton;

						DialogResult result = inputForm.ShowDialog();

						// If OK was clicked and text is not empty or unchanged
						if (result == DialogResult.OK && !string.IsNullOrEmpty(textBox.Text) && textBox.Text != currentFirstName)
						{
							UpdateFirstName(textBox.Text);
						}
					}
				}
				else
				{
					MessageBox.Show("Please select a user record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error editing first name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void UpdateFirstName(string newFirstName)
		{
			try
			{
				string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\StudentDB.mdf;Integrated Security=True";

				using (SqlConnection con = new SqlConnection(connectionString))
				{
					con.Open();

					string updateQuery = "UPDATE Students SET first = @newFirstName WHERE email = @email";

					SqlCommand cmd = new SqlCommand(updateQuery, con);
					cmd.Parameters.AddWithValue("@newFirstName", newFirstName);
					cmd.Parameters.AddWithValue("@email", userEmail);

					int rowsAffected = cmd.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						MessageBox.Show("First name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						// Refresh the data grid to show the updated information
						LoadUserInformation();
					}
					else
					{
						MessageBox.Show("No records were updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error updating first name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			// Show confirmation dialog
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

						// Get the ID of the student before deleting
						string getIdQuery = "SELECT gwid FROM Students WHERE email = @email";
						SqlCommand getIdCmd = new SqlCommand(getIdQuery, con);
						getIdCmd.Parameters.AddWithValue("@email", userEmail);

						object studentId = getIdCmd.ExecuteScalar();

						if (studentId != null)
						{
							// Begin transaction for cascading delete
							using (SqlTransaction transaction = con.BeginTransaction())
							{
								try
								{
									// Delete from Taking table
									SqlCommand deleteTakingCmd = new SqlCommand(
										"DELETE FROM Taking WHERE gwid = @id", con, transaction);
									deleteTakingCmd.Parameters.AddWithValue("@id", studentId);
									deleteTakingCmd.ExecuteNonQuery();

									// Delete from MustPay relationship
									SqlCommand deleteMustPayCmd = new SqlCommand(
										"DELETE FROM MustPay WHERE gwid = @id", con, transaction);
									deleteMustPayCmd.Parameters.AddWithValue("@id", studentId);
									deleteMustPayCmd.ExecuteNonQuery();

									// Delete from Has relationship (scholarships)
									SqlCommand deleteHasCmd = new SqlCommand(
										"DELETE FROM Has WHERE gwid = @id", con, transaction);
									deleteHasCmd.Parameters.AddWithValue("@id", studentId);
									deleteHasCmd.ExecuteNonQuery();

									// Delete from IsA relationship
									SqlCommand deleteIsACmd = new SqlCommand(
										"DELETE FROM IsA WHERE gwid = @id", con, transaction);
									deleteIsACmd.Parameters.AddWithValue("@id", studentId);
									deleteIsACmd.ExecuteNonQuery();

									// Finally delete from Students table
									SqlCommand deleteStudentCmd = new SqlCommand(
										"DELETE FROM Students WHERE gwid = @id", con, transaction);
									deleteStudentCmd.Parameters.AddWithValue("@id", studentId);
									deleteStudentCmd.ExecuteNonQuery();

									// Commit all changes
									transaction.Commit();

									MessageBox.Show("User and all related records have been deleted successfully.",
										"Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

									// Return to login form
									this.Hide();
									Form_login loginForm = new Form_login();
									loginForm.Show();
								}
								catch (Exception ex)
								{
									// Roll back transaction if any error occurs
									transaction.Rollback();
									MessageBox.Show("Transaction error: " + ex.Message,
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
						}
						else
						{
							MessageBox.Show("Could not find user with email: " + userEmail,
								"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message,
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}