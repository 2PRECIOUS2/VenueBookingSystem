using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class MyProfile : Form
    {
        bool isEditMode = false;
        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public MyProfile()
        {
            InitializeComponent();
            
        }

        private void LoadProfileData()
        {
            

            string query;
            if (Users.LoggedInUserType == "Student")
            {
                // Query for student table
                query = "SELECT FirstName, LastName, Email, PhoneNumber FROM Student WHERE Student_ID = @UserID";
            }
            else if (Users.LoggedInUserType == "Lecturer")
            {
                // Query for lecturer table
                query = "SELECT FirstName, LastName, Email, PhoneNumber FROM Lecturer WHERE Lecturer_ID = @UserID";
            }
            else
            {
                MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", Users.LoggedInUserID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the form with user data
                            txtFName.Text = reader["FirstName"].ToString();
                            txtLName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            mskTxtPhoneNo.Text = reader["PhoneNumber"].ToString();

                            // Display user ID and type on the form
                            lblUserName.Text = reader["FirstName"].ToString();
                            lblID.Text = Users.LoggedInUserID;
                            lblUserType.Text = Users.LoggedInUserType;
                        }
                        else
                        {
                            MessageBox.Show("User details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading profile data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Set fields to read-only initially
            txtFName.ReadOnly = true;
            txtLName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            mskTxtPhoneNo.ReadOnly = true;
        }

       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = !isEditMode; // Toggle edit mode
            SetEditMode(isEditMode);
        }

        private void SetEditMode(bool editMode)
        {
            // First Name and Last Name should remain read-only, no matter what
            txtFName.ReadOnly = true;
            txtLName.ReadOnly = true;

            // Enable/Disable email and phone number editing
            txtEmail.ReadOnly = !editMode;
            mskTxtPhoneNo.ReadOnly = !editMode;
            btnSave.Enabled = editMode;

            // Disable buttons that should not be active during edit mode
            btnDelete.Enabled = !editMode;
            btnChangePassword.Enabled = !editMode;
            btnHome.Enabled = !editMode;

            // Update the "Edit" button's text based on the mode
            btnEdit.Text = editMode ? "Cancel" : "Edit";
        }

        private bool ValidateInputFields()
        {
            bool isValid = true;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Generic email regex pattern

            // Email validation
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            // Clean phone number before validation
            string phoneNumber = mskTxtPhoneNo.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                errorProvider1.SetError(mskTxtPhoneNo, "Please enter a valid 10-digit phone number");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(mskTxtPhoneNo, "");
            }

            return isValid;
        }

        private bool CheckExistingEmail(string email)
        {
            bool emailExists = false;
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();

                    // Query to check if email exists in Student table
                    string queryStudent = "SELECT COUNT(*) FROM Student WHERE Email = ?";
                    using (OleDbCommand cmdStudent = new OleDbCommand(queryStudent, conn))
                    {
                        cmdStudent.Parameters.AddWithValue("@Email", txtEmail.Text);
                        int studentCount = (int)cmdStudent.ExecuteScalar();

                        if (studentCount > 0)
                        {
                            emailExists = true;
                        }
                    }

                    // If email was not found in Student, check Lecturer table
                    if (!emailExists)
                    {
                        string queryLecturer = "SELECT COUNT(*) FROM Lecturer WHERE Email = ?";
                        using (OleDbCommand cmdLecturer = new OleDbCommand(queryLecturer, conn))
                        {
                            cmdLecturer.Parameters.AddWithValue("@Email", txtEmail.Text);
                            int lecturerCount = (int)cmdLecturer.ExecuteScalar();

                            if (lecturerCount > 0)
                            {
                                emailExists = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return emailExists;
        }

        private bool IsValidPassword(string password)
        {
            // Password should be at least 8 characters, contain uppercase, lowercase, digit, and special character
            return password.Length >= 8
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsDigit)
                && password.Any(ch => "!@#$%^&*()_+-=[]{}|;':\",.<>?/`~".Contains(ch))
                && !password.Contains(" ");
        }

        private bool VerifyCurrentPassword(string currentPassword)
        {
            string query = string.Empty;

            // Determine which table to query based on the user type
            if (Users.LoggedInUserType == "Student")
            {
                query = "SELECT Password FROM [Student] WHERE StudentID = @UserID";
            }
            else if (Users.LoggedInUserType == "Lecturer")
            {
                query = "SELECT Password FROM [Lecturer] WHERE LecturerID = @UserID";
            }


            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer) { Value = int.Parse(Users.LoggedInUserID) });

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error verifying password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        private void UpdatePasswordInDatabase(int userID, string newPassword)
        {
            string query = string.Empty;

            // Determine which table to update based on the user type
            if (Users.LoggedInUserType == "Student")
            {
                query = "UPDATE [Student] SET [Password] = @NewPassword WHERE Student_ID = @UserID";
            }
            else if (Users.LoggedInUserType == "Lecturer")
            {
                query = "UPDATE [Lecturer] SET [Password] = @NewPassword WHERE Lecturer_ID = @UserID";
            }

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@NewPassword", OleDbType.VarChar) { Value = newPassword });
                        cmd.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer) { Value = userID });

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePassword()
        {
            using (Form changePassDialog = new Form())
            {
                changePassDialog.Text = "Change Password";
                changePassDialog.Size = new Size(350, 250);

                Label lblCurrentPassword = new Label() { Text = "Current Password:", Location = new Point(10, 20), AutoSize = true };
                TextBox txtCurrentPassword = new TextBox() { Location = new Point(150, 20), Width = 150, PasswordChar = '*' };

                Label lblNewPassword = new Label() { Text = "New Password:", Location = new Point(10, 60), AutoSize = true };
                TextBox txtNewPassword = new TextBox() { Location = new Point(150, 60), Width = 150, PasswordChar = '*' };

                Label lblConfirmPassword = new Label() { Text = "Confirm Password:", Location = new Point(10, 100), AutoSize = true };
                TextBox txtConfirmPassword = new TextBox() { Location = new Point(150, 100), Width = 150, PasswordChar = '*' };

                Button btnSubmit = new Button() { Text = "Submit", Location = new Point(150, 150), Width = 80 };

                changePassDialog.Controls.Add(lblCurrentPassword);
                changePassDialog.Controls.Add(txtCurrentPassword);
                changePassDialog.Controls.Add(lblNewPassword);
                changePassDialog.Controls.Add(txtNewPassword);
                changePassDialog.Controls.Add(lblConfirmPassword);
                changePassDialog.Controls.Add(txtConfirmPassword);
                changePassDialog.Controls.Add(btnSubmit);

                btnSubmit.Click += (sender, e) =>
                {
                    if (string.IsNullOrEmpty(txtCurrentPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
                    {
                        MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtNewPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!VerifyCurrentPassword(txtCurrentPassword.Text))
                    {
                        MessageBox.Show("The current password is incorrect.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    UpdatePasswordInDatabase(int.Parse(Users.LoggedInUserID), txtNewPassword.Text);
                    MessageBox.Show("Your password has been changed successfully.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changePassDialog.Close();
                };

                changePassDialog.ShowDialog();
            }
        }

        private void SaveChangesToDatabase()
        {
            

            string query;
            if (Users.LoggedInUserType == "Student")
            {
                query = "UPDATE Student SET Email = @Email, PhoneNumber = @PhoneNumber WHERE Student_ID = @UserID";
            }
            else if (Users.LoggedInUserType == "Lecturer")
            {
                query = "UPDATE Lecturer SET Email = @Email, PhoneNumber = @PhoneNumber WHERE Lecturer_ID = @UserID";
            }
            else
            {
                MessageBox.Show("Unknown user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", mskTxtPhoneNo.Text);
                    cmd.Parameters.AddWithValue("@UserID", Users.LoggedInUserID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputFields())
            {
               if (CheckExistingEmail(txtEmail.Text))
                {
                    MessageBox.Show("The email you entered already exists", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                // Save the changes to the database
                SaveChangesToDatabase();
                MessageBox.Show("Your changes have been saved successfully", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Exit edit mode after saving
                SetEditMode(false);
            }
        }

        private void DeleteUserProfile()
        {
            string query = "";

            // Determine the query based on the user type (Student or Lecturer)
            if (Users.LoggedInUserType == "Student")
            {
                query = "DELETE FROM Student WHERE UserID = @UserID";
            }
            else if (Users.LoggedInUserType == "Lecturer")
            {
                query = "DELETE FROM Lecturer WHERE UserID = @UserID";
            }

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer) { Value = int.Parse(Users.LoggedInUserID) });
                        cmd.ExecuteNonQuery(); // Execute the deletion query
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool HasBookings(int userID)
        {
            // Query to check if the user has any currently active bookings (where current time is between StartDateTime and EndDateTime)
            string query = @"
    SELECT COUNT(*) 
    FROM Booking
    WHERE UserID = @UserID 
    AND @CurrentDateTime BETWEEN StartDateTime AND EndDateTime";
            // Consider bookings where current time is between StartDateTime and EndDateTime

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add parameters for UserID and current DateTime
                        cmd.Parameters.Add(new OleDbParameter("@UserID", OleDbType.Integer) { Value = userID });
                        cmd.Parameters.Add(new OleDbParameter("@CurrentDateTime", OleDbType.Date) { Value = DateTime.Now });

                        int count = (int)cmd.ExecuteScalar(); // Get the count of active bookings
                        return count > 0; // If count > 0, the user has an active booking
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Return true on error to prevent accidental profile deletion
                }
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Users.LoggedInUserID); // Parse UserID once for reuse

            // Check if user has active bookings
            if (HasBookings(userID))
            {
                MessageBox.Show("Cannot delete profile as you have active future bookings.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm if the user wants to proceed with deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete your profile?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Proceed with profile deletion
                DeleteUserProfile();
                MessageBox.Show("Your profile has been successfully deleted.", "Profile Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form and navigate to the homepage
                ClearFormAndReturnToHomePage();
            }
        }

        private void ClearFormAndReturnToHomePage()
        {
            // Clear form fields
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            mskTxtPhoneNo.Clear();

            // Close the current form
            this.Close();

            // Redirect to home page (replace `HomePage` with your actual home page form class)
            HomePage home = new HomePage();
            home.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenuPage mainMenuPage = new MainMenuPage(); 
            this.Visible = false;
            mainMenuPage.ShowDialog();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        { 
            LoadProfileData();
        }
    }
}
