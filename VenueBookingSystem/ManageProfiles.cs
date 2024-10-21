using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class ManageProfiles : Form
    {
        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";

        public ManageProfiles()
        {
            InitializeComponent();
        }

        private bool ValidateFormInput(bool blnValidInput)
        {
            FormInputerrorProvider.Clear();
            if(cmbUserType.SelectedIndex == -1)
            {
                blnValidInput = false; 
                FormInputerrorProvider.SetError(cmbUserType, "Please select the typeof user");
                
            }

            if(txtUserID.Text == "")
            {
                blnValidInput = false ;
                FormInputerrorProvider.SetError(txtUserID, "User ID cannot be empty");
            }
            return blnValidInput;
        }



         
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);
            if (blnValidInput == true)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionstring))
                try
                {
                    conn.Open();
                    string query = "";
                   


                        string userType = cmbUserType.SelectedItem.ToString();

                        if (userType == "Student")
                        {
                            query = "SELECT * FROM Student WHERE Student_ID = ?";

                        }
                        else if (userType == "Lecturer")
                        {
                            query = "SELECT * FROM Lecturer WHERE Lecturer_ID = ?";

                        }
                        else
                        {
                            MessageBox.Show("Please select a valid User Type.");
                            return;
                        }


                        OleDbCommand command = new OleDbCommand(query, conn);
                        command.Parameters.AddWithValue("@ID", txtUserID.Text);  // TextBox for User ID

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            // If no rows were found, display a message
                            MessageBox.Show("User not found.");
                            return;
                        }

                        // Display the data in the DataGridView
                        dataGridView1.DataSource = dataTable;
                        //MaskPasswordColumn();
                        dataGridView1.Columns["Password"].ReadOnly = true;  
                        if (userType == "Student")
                        {
                            dataGridView1.Columns["Student_ID"].ReadOnly = true;  // ID
                                                                                  // dataGridView1.Columns["Password"].ReadOnly = true;   // Password
                        }
                        else if (userType == "Lecturer")
                        {
                            dataGridView1.Columns["Lecturer_ID"].ReadOnly = true;   
                        }
                    }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }
        }

        /*private void MaskPasswordColumn()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Password"].Value != null)
                {
                    row.Cells["Password"].Value = new string('*', row.Cells["Password"].Value.ToString().Length);
                }
            }
        }*/

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
                {
                    try
                    {
                        conn.Open();
                        string userType = cmbUserType.SelectedItem.ToString();
                        string query = "";

                        if (userType == "Student")
                        {
                            query = "UPDATE Student SET FirstName = ?, LastName = ?, Email = ?, PhoneNumber = ? WHERE Student_ID = ?";
                        }
                        else if (userType == "Lecturer")
                        {
                            query = "UPDATE Lecturer SET FirstName = ?,LastName = ?, Email = ?, PhoneNumber = ? WHERE Lecturer_ID = ?";
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid User Type.");
                            return;
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            OleDbCommand command = new OleDbCommand(query, conn);
                            command.Parameters.AddWithValue("@FirstName", row.Cells["FirstName"].Value);
                            command.Parameters.AddWithValue("@LastName", row.Cells["LastName"].Value);
                            command.Parameters.AddWithValue("@Email", row.Cells["Email"].Value);
                            command.Parameters.AddWithValue("@PhoneNumber", row.Cells["PhoneNumber"].Value);

                            if (userType == "Student")
                            {
                                command.Parameters.AddWithValue("@Student_ID", row.Cells["Student_ID"].Value);
                            }
                            else if (userType == "Lecturer")
                            {
                                command.Parameters.AddWithValue("@Lecturer_ID", row.Cells["Lecturer_ID"].Value);
                            }

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Profile updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // If the admin clicks "Yes"
            if (result == DialogResult.Yes)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionstring))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "";
                        string userType = cmbUserType.SelectedItem.ToString();  // Retrieve user type
                        string idColumn = "";  // This will store the name of the ID column (StudentID or LecturerID)

                        // Determine the correct table and ID column based on user type
                        if (userType == "Student")
                        {
                            deleteQuery = "DELETE FROM Student WHERE Student_ID = ?";
                            idColumn = "Student_ID";
                        }
                        else if (userType == "Lecturer")
                        {
                            deleteQuery = "DELETE FROM Lecturer WHERE Lecturer_ID = ?";
                            idColumn = "Lecturer_ID";
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type");
                            return;
                        }

                        // Get the selected user ID
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            // Assuming the ID is in the selected row
                            string selectedID = dataGridView1.SelectedRows[0].Cells[idColumn].Value.ToString();

                            // Execute the delete query
                            using (OleDbCommand command = new OleDbCommand(deleteQuery, conn))
                            {
                                command.Parameters.AddWithValue($"@{idColumn}", selectedID);
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show("User deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Please select a user to delete.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                // If the admin clicks "No", cancel the deletion
                MessageBox.Show("Deletion canceled.");
            }
        }

        private bool ValidateData()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        MessageBox.Show("All fields must be filled.");
                        return false;
                    }
                }

                // Assuming the phone number column is named "PhoneNumber"
                string phoneNumber = row.Cells["PhoneNumber"].Value.ToString();
                if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Phone number must be 10 digits.");
                    return false;
                }
            }
            return true;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            AdminMainMenuPage mainMenuPage = new AdminMainMenuPage();
            this.Visible = false;
            mainMenuPage.ShowDialog();
        }

       
    }

}
