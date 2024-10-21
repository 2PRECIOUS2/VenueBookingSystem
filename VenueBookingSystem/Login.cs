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
    public partial class Login : Form
    {

         OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StudentLogin()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");
            conn.Open();
            cmd = new OleDbCommand("SELECT * FROM Student WHERE Student_ID = ? AND Password = ?", conn);

            // Add parameters with values
            cmd.Parameters.AddWithValue("@Student_ID", txtUserID.Text); // Assuming you have a TextBox for Student ID
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);    // Assuming you have a TextBox for Password

            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Login Successful");
                Users.LoggedInUserID = txtUserID.Text;
                Users.LoggedInUserType = cmbUserType.SelectedItem.ToString();
                this.Hide();  // Hide the current login form
                MainMenuPage mainMenu = new MainMenuPage(); // Assuming you have a MainMenu form
                mainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, Please Re-Enter");
            }

            conn.Close();
            

        }

        private void LecturerLogin()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");
            conn.Open();
            cmd = new OleDbCommand("SELECT * FROM Lecturer WHERE Lecturer_ID = ? AND Password = ?", conn);

            // Add parameters with values
            cmd.Parameters.AddWithValue("@Lecturer_ID", txtUserID.Text); 
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);    

            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Login Successful");
                // When the user logs in successfully:
                Users.LoggedInUserID = txtUserID.Text;
                Users.LoggedInUserType = cmbUserType.SelectedItem.ToString();

                this.Hide();  // Hide the current login form
                MainMenuPage mainMenu = new MainMenuPage(); 
                mainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, Please Re-Enter");
            }

            conn.Close();
            

        }

        private void AdminLogin()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");
            conn.Open();
            cmd = new OleDbCommand("SELECT * FROM Admin WHERE Admin_ID = ? AND AdminPassword = ?", conn);

            // Add parameters with values
            cmd.Parameters.AddWithValue("@Admin_ID", txtUserID.Text); 
            cmd.Parameters.AddWithValue("@AdminPassword", txtPassword.Text);    

            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Login Successful");
                this.Hide();  // Hide the current login form
                AdminMainMenuPage mainMenu = new AdminMainMenuPage(); 
                mainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, Please Re-Enter");
            }

            conn.Close();


        }
        private bool ValidateFormInput(bool blnValidFormInput)
        {
            errorProvider2.Clear();
            if(cmbUserType.SelectedItem == null)
            {
                blnValidFormInput = false;
                errorProvider2.SetError(cmbUserType, "Please select the type of user");
            }

            if (txtUserID.Text == "")
            {
                blnValidFormInput = false;
                errorProvider2.SetError(txtUserID, "Incorrect UserID");
            }
            if(txtPassword.Text == "")
            {
                blnValidFormInput = false ;
                errorProvider2.SetError(txtPassword, "Incorrect password");
            }

            return blnValidFormInput;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                // Show the password
                txtPassword.PasswordChar = '\0';  // '\0' makes the characters visible
            }
            else
            {
                // Hide the password
                txtPassword.PasswordChar = '*';  // Mask the characters with '*'
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);
            if (blnValidInput == true)
            {
                if (cmbUserType.Text == "Student")
                {
                        StudentLogin(); 
                    }
                

                else if (cmbUserType.Text == "Lecturer")
                {
                        LecturerLogin();
                    }

                    else if (cmbUserType.Text == "Admin")
                    {
                        AdminLogin();
                    }
                
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            this.Visible = false;
            homepage.ShowDialog();
        }


       
    }
}
