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
    public partial class ManageVenues : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public ManageVenues()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearchVenue_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearchVenue.Text;

            // Assuming you fetch the venue data from the database
            string query = "SELECT VenueName FROM Venue WHERE VenueName LIKE ?";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", "%" + searchQuery + "%");

                    try
                    {
                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        List<string> venueNames = new List<string>();
                        while (reader.Read())
                        {
                            venueNames.Add(reader["VenueName"].ToString());
                        }

                        // Update ComboBox or ListBox with filtered venue names
                        cmbVenues.DataSource = venueNames;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void cmbVenues_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedVenue = cmbVenues.SelectedItem?.ToString();

            // Check if a valid venue is selected
            if (string.IsNullOrEmpty(selectedVenue))
            {
                MessageBox.Show("Please select a valid venue.");
                return;
            }
            string query = "SELECT VenueID, VenueName, VenueCapacity, CategoryOfVenue, VenueLocation FROM Venue WHERE VenueName = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", selectedVenue);

                    try
                    {
                        // Open the connection
                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        // Clear any previous rows from the DataGridView
                        VenueDetailsGridView.Rows.Clear();
                        if (VenueDetailsGridView.Columns.Count == 0)
                        {
                            VenueDetailsGridView.Columns.Add("VenueID", "Venue ID");
                            VenueDetailsGridView.Columns.Add("VenueName", "Venue Name");
                            VenueDetailsGridView.Columns.Add("VenueCapacity", "Capacity");
                            VenueDetailsGridView.Columns.Add("CategoryOfVenue", "Category Of Venue");
                            VenueDetailsGridView.Columns.Add("VenueLocation", "Location");
                            VenueDetailsGridView.Columns["VenueID"].ReadOnly = true;
                        }

                            // Check if the reader has any data to read
                            if (reader.Read())
                        {
                            // Add the retrieved data to the DataGridView
                            VenueDetailsGridView.Rows.Add(reader["VenueID"].ToString(),
                                                          reader["VenueName"].ToString(),
                                                          reader["VenueCapacity"].ToString(),
                                                          reader["CategoryOfVenue"].ToString(),
                                                          reader["VenueLocation"].ToString());
                        }
                        else
                        {
                            // If no data is found for the selected venue
                            MessageBox.Show("No details found for the selected venue.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the database operation
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
           
            
        }

        private void btnUpdateVenue_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (VenueDetailsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a venue to update.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = VenueDetailsGridView.SelectedRows[0];

            // Fetch updated values from the selected row in DataGridView
            int venueID = Convert.ToInt32(selectedRow.Cells["VenueID"].Value);
            string venueName = selectedRow.Cells["VenueName"].Value.ToString();
            int updatedCapacity = Convert.ToInt32(selectedRow.Cells["VenueCapacity"].Value);
            string updatedVenueType = selectedRow.Cells["CategoryOfVenue"].Value.ToString();
            string updatedLocation = selectedRow.Cells["VenueLocation"].Value.ToString();

            string checkBookingQuery = "SELECT COUNT(*) FROM Booking WHERE VenueID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand checkCmd = new OleDbCommand(checkBookingQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("?", venueID);

                    try
                    {
                        // Open connection
                        conn.Open();

                        // Execute the query to check if the venue is booked
                        int bookingCount = (int)checkCmd.ExecuteScalar();

                        if (bookingCount > 0)
                        {
                            // Venue is booked, prevent update
                            MessageBox.Show("This venue is currently booked and cannot be updated.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking booking status: " + ex.Message);
                        return;
                    }
                }
            }

                // Prepare the SQL query for updating the venue
                string query = "UPDATE Venue SET VenueName = ?, VenueCapacity = ?, CategoryOfVenue = ?, VenueLocation = ? WHERE VenueID = ?";

            // Create and open the OleDb connection
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // Add parameters for the update
                   
                    cmd.Parameters.AddWithValue("?", venueName);
                    cmd.Parameters.AddWithValue("?", updatedCapacity);
                    cmd.Parameters.AddWithValue("?", updatedVenueType);
                    cmd.Parameters.AddWithValue("?", updatedLocation);
                    cmd.Parameters.AddWithValue("?", venueID);



                    try
                    {
                        // Open the connection and execute the update query
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Venue updated successfully.");
                            // Optionally, refresh the DataGridView to reflect the updated data
                            
                        }
                        else
                        {
                            MessageBox.Show("No venue was updated. Please check the details.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnDeleteVenue_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (VenueDetailsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a venue to delete.");
                return;
            }

            // Get the selected row and delete the venue (as discussed earlier)
            DataGridViewRow selectedRow = VenueDetailsGridView.SelectedRows[0];
            int venueID = Convert.ToInt32(selectedRow.Cells["VenueID"].Value);
            string venueName = selectedRow.Cells["VenueName"].Value.ToString();

            // Confirm deletion
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete the selected venue?",
                                                         "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string checkBookingQuery = "SELECT COUNT(*) FROM Booking WHERE VenueID = ?";

                using (OleDbConnection conn = new OleDbConnection(connectionstring))
                {
                    using (OleDbCommand checkCmd = new OleDbCommand(checkBookingQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", venueID);

                        try
                        {
                            conn.Open();

                            // Execute the query to check if the venue is booked
                            int bookingCount = (int)checkCmd.ExecuteScalar();

                            if (bookingCount > 0)
                            {
                                // Venue is booked, prevent deletion
                                MessageBox.Show("This venue is currently booked and cannot be deleted.");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking booking status: " + ex.Message);
                            return;
                        }
                    }
                }

                    // Prepare the SQL query for deleting the venue
                    string query = "DELETE FROM Venue WHERE VenueName = ?";

                // Create and open the OleDb connection
                using (OleDbConnection conn = new OleDbConnection(connectionstring))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", venueName);

                        try
                        {
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Venue deleted successfully.");
                                // Refresh the DataGridView
                                
                               FilterVenuesByText(cmbVenues.Text);  // Call the same method that filters venues
                                cmbVenues.SelectedIndex = -1;
                            }
                            else
                            {
                                MessageBox.Show("No venue was deleted. Please check the selected venue.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        // Method to filter venues dynamically based on the text typed in the ComboBox
        private void cmbVenues_TextChanged(object sender, EventArgs e)
        {
            string searchText = cmbVenues.Text.Trim();
            FilterVenuesByText(searchText);  // Reuse this method to filter and display venues
        }

        // Method to filter venues by the entered text
        private void FilterVenuesByText(string searchText)
        {
            string query = "SELECT * FROM Venue WHERE VenueID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", "%" + searchText + "%");

                    try
                    {
                        conn.Open();
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        VenueDetailsGridView.DataSource = dt;  // Update the DataGridView with the filtered data
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private bool ValidateFormInput(bool blnValidInput)
        {
            errorProviderFormInput.Clear();
            if (txtVenueName.Text == "") 
            {
                blnValidInput = false;
                errorProviderFormInput.SetError(txtVenueName, "Pleaae enter a venue name");
            }

            int selectedCapacity = (int)nudVenueCapacity.Value;
            if (nudVenueCapacity.Value < 1)
            {
                blnValidInput = false ;
                errorProviderFormInput.SetError(nudVenueCapacity, "Venue Capacity should be grater than 0");
            }

            string selectedCategory = cmbVeneuCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCategory))
            {
                blnValidInput = false ;
                errorProviderFormInput.SetError(cmbVeneuCategory, "Please select a venue category");
            }

            if(txtVenueLocation.Text == "")
            {
                blnValidInput = false ;
                errorProviderFormInput.SetError(txtVenueLocation, "Please enter a venue location");
            }

            return blnValidInput;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);

            if (blnValidInput == true)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionstring))
                {
                    conn.Open();
                    string sql = "INSERT INTO Venue ([VenueName], [VenueCapacity], [CategoryOfVenue], [VenueLocation]) VALUES (?, ?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@VenueName", txtVenueName.Text);
                        command.Parameters.AddWithValue("@VenueCapacity", nudVenueCapacity.Value);
                        command.Parameters.AddWithValue("@CategoryOfVenue", cmbVeneuCategory.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@VenueLocation", txtVenueLocation.Text);
                        

                        command.ExecuteNonQuery();
                        MessageBox.Show("Venue added successfully");
                       
                        Clear();
                    }
                }
            }
        }
        

        private void Clear()
        {
            txtVenueName.Text = string.Empty;
            cmbVeneuCategory.SelectedIndex = -1;
            nudVenueCapacity.Value = 0;
            txtVenueLocation.Text = string.Empty;
            txtVenueName.Focus();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            AdminMainMenuPage adminMainMenuPage = new AdminMainMenuPage();
            this.Visible = false;
            adminMainMenuPage.ShowDialog();
        }
    }
}
