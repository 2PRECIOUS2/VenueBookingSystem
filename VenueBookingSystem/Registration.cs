using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class Registration : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public void refreshGridStudent()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT TOP 1 Student_ID, FirstName, LastName, Email, PhoneNumber FROM Student ORDER BY Student_ID DESC";


                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Connection:" + e);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void refreshGridLecturer()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT TOP 1 Lecturer_ID, FirstName, LastName, Email, PhoneNumber FROM Lecturer ORDER BY Lecturer_ID DESC";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Connection:" + e);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public Registration()
        {
            InitializeComponent();

        }
        private bool ValidateFormInput(bool blnValidInput)
        {
            errorProvider1.Clear();

            if (txtFname.Text == "")
            {
                blnValidInput = false;
                errorProvider1.SetError(txtFname, "Please enter your First name.");
            }

            if (txtLname.Text == "")
            {
                blnValidInput = false;
                errorProvider1.SetError(txtLname, "Please enter your Last name.");

            }

            if (txtEmail.Text == "" || !IsValidEmail(txtEmail.Text))
            {
                blnValidInput = false;
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");

            }

            if (!IsPhoneNumberValid(mskTxtPhoneNo.Text))
            {
                blnValidInput = false;
                errorProvider1.SetError(mskTxtPhoneNo, "Please enter a complete phone number.");
            }

            if (!IsPasswordValid(txtPassword.Text))
            {
                blnValidInput = false;
                errorProvider1.SetError(txtPassword, "Please enter a valid Password.");
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                blnValidInput = false;
                errorProvider1.SetError(txtConfirmPassword, "Password does not match.");
            }

            if (radStudent.Checked == false && radLecturer.Checked == false)
            {
                blnValidInput = false;
                errorProvider1.SetError(grpBoxUserType, "Select the type of user.");

            }


            return blnValidInput;
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression to match email pattern (email@domain.tld)
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // Regular expression for validating phone numbers
            string pattern = @"^\(\d{3}\)-\d{3}-\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }


        public static bool IsPasswordValid(string password)
        {
            // Regular expression to validate the password
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private string GetSelectedUserType(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        private bool EmailExists(string email)
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

        private void checkBoxShowPassword(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                // Show the password
                txtPassword.PasswordChar = '\0';  // '\0' makes the characters visible
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                // Hide the password
                txtPassword.PasswordChar = '*';  // Mask the characters with '*'
                txtConfirmPassword.PasswordChar = '*';
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {

            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);

            string userType = GetSelectedUserType(grpBoxUserType);
            if (blnValidInput == true)
            {
                string email = txtEmail.Text;

                if (EmailExists(email))
                {
                    MessageBox.Show("Email already exists. Please use a different email.");
                    return;  // Exit registration process if email exists
                }


                if (userType == "Student")
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionstring))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Student ([FirstName], [Lastname], [Email], [PhoneNumber], [Password], [UserType]) VALUES (?, ?, ?, ?, ?, ?)";
                        using (OleDbCommand command = new OleDbCommand(sql, conn))
                        {
                            command.Parameters.AddWithValue("@FirstName", txtFname.Text);
                            command.Parameters.AddWithValue("@LastName", txtLname.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);
                            command.Parameters.AddWithValue("@PhoneNo", mskTxtPhoneNo.Text);
                            command.Parameters.AddWithValue("@Password", txtPassword.Text);
                            command.Parameters.AddWithValue("@UserType", userType);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Registration successful");
                            clear();
                            refreshGridStudent();


                        }
                    }
                }

                else if (userType == "Lecturer")
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionstring))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Lecturer ([FirstName], [Lastname], [Email], [PhoneNumber], [Password], [UserType]) VALUES (?, ?, ?, ?, ?, ?)";
                        using (OleDbCommand command = new OleDbCommand(sql, conn))
                        {
                            command.Parameters.AddWithValue("@FirstName", txtFname.Text);
                            command.Parameters.AddWithValue("@LastName", txtLname.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);
                            command.Parameters.AddWithValue("@PhoneNo", mskTxtPhoneNo.Text);
                            command.Parameters.AddWithValue("@Password", txtPassword.Text);
                            command.Parameters.AddWithValue("@UserType", userType);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Registration successful");
                            clear();
                            refreshGridLecturer();


                        }
                    }
                }

            }

        }
    
 

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            this.Visible = false;
            homepage.ShowDialog();
        }

        private void clear()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtEmail.Text = "";
            mskTxtPhoneNo.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            radLecturer.Checked = false;
            radStudent.Checked = false;
            txtFname.Focus();

        }
   
    }
}
