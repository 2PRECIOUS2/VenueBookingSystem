using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
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
        public void refreshGrid()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Student", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection:" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public Registration()
        {
            InitializeComponent();
            refreshGrid();


        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateFormInput(bool blnValidInput)
        {
            errorProvider1.Clear();

            if (txtFname.Text == "")
            {
                blnValidInput = false;
                errorProvider1.SetError(txtFname, "Please enter your First name.");
            }

            if(txtLname.Text == "")
            {
                blnValidInput = false;
                errorProvider1.SetError(txtLname, "Please enter your Last name.");
          
            }

            if(txtEmail.Text == "" || !IsValidEmail(txtEmail.Text))
            {
                blnValidInput = false;
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
                
            }

            if (!IsPhoneNumberValid(mskTxtPhoneNo.Text))
            {
                errorProvider1.SetError(mskTxtPhoneNo, "Please enter a complete phone number.");
            }

            if (!IsPasswordValid(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Please enter a valid Password.");
            }

            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password does not match.");
            }

            if(radStudent.Checked == false && radLecturer.Checked == false)
            {
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
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
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
            return string.Empty; // or a default value if no radio button is selected
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);

            if (blnValidInput == true)
            {
                string userType = GetSelectedUserType(grpBoxUserType);
                
                
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
