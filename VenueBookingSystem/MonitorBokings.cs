using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class MonitorBokings : Form
    {
        public MonitorBokings()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        private void AddActionButtonsToGridView()
        {
            // Add the three dots button (Ellipsis) for actions
            DataGridViewButtonColumn ellipsisColumn = new DataGridViewButtonColumn();
            ellipsisColumn.Name = "Actions";
            ellipsisColumn.Text = "⋮";  // Three vertical dots
            ellipsisColumn.UseColumnTextForButtonValue = true;
            
                dgvActiveBookings.Columns.Add(ellipsisColumn);
            

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset all fields
            txtUserID.Enabled = true;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            nudMinCapacity.Enabled = true;
            nudMaxCapacity.Enabled = true;
            txtVenueName.Enabled = true;

            // Disable fields based on selection
            switch (cmbSearchFilters.SelectedItem.ToString())
            {
                case "Date":
                    txtUserID.Enabled = false;
                    nudMinCapacity.Enabled = false;
                    nudMaxCapacity.Enabled = false;
                    nudDuration.Enabled = false;
                    txtVenueName.Enabled = false;
                    break;
                case "Capacity":
                    txtUserID.Enabled = false;
                    dtpStartDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    nudDuration.Enabled = false;
                    txtVenueName.Enabled = false;
                    break;
                case "User ID":
                    dtpStartDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    nudMinCapacity.Enabled = false;
                    nudMaxCapacity.Enabled = false;
                    nudDuration.Enabled = false;
                    txtVenueName.Enabled = false;
                    break;
                case "Venue Name":
                    dtpStartDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    nudMinCapacity.Enabled = false;
                    nudMaxCapacity.Enabled = false;
                    nudDuration.Enabled = false;
                    txtUserID.Enabled = false;
                    break;
                case "Duration":
                    dtpStartDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    nudMinCapacity.Enabled = false;
                    nudMaxCapacity.Enabled = false;
                    txtVenueName.Enabled = false;
                    txtUserID.Enabled = false;
                    break;
            }
        }

            private void MonitorBokings_Load(object sender, EventArgs e)
        {
            
                AddActionButtonsToGridView();
            dgvActiveBookings.CellContentClick += dgvActiveBookings_CellContentClick;

        }

        private bool FormInput(bool blnValidInput)
        {
            // Validate Search Filters ComboBox
            if (cmbSearchFilters.SelectedIndex == -1)  // This checks if no item is selected
            {
                blnValidInput = false;
                MessageBox.Show("Please select a search filter (e.g., Date, Capacity, etc.).", "Search Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSearchFilters.Focus();  // Set focus back to the ComboBox
            }

            // Validate User Type ComboBox only if the Search Filter is "User ID"
            else if (cmbSearchFilters.SelectedItem.ToString() == "User ID")
            {
                if (cmbUserType.SelectedIndex == -1)  // Check if no user type is selected
                {
                    blnValidInput = false;
                    MessageBox.Show("Please select a user type (Student or Lecturer).", "User Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbUserType.Focus();  // Set focus back to the ComboBox
                }
            }

            // Validate Venue Name if the Search Filter is set to "Venue Name"
            else if (cmbSearchFilters.SelectedItem.ToString() == "Venue Name")
            {
                if (string.IsNullOrWhiteSpace(txtVenueName.Text))  // Check if the Venue Name textbox is empty
                {
                    blnValidInput = false;
                    MessageBox.Show("Venue Name cannot be empty. Please enter a valid venue name.", "Venue Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVenueName.Focus();  // Set focus back to the Venue Name textbox
                }
            }


                return blnValidInput;
        }

        private DataTable LoadBookings()
        {
           
            string query = "SELECT Booking_ID, TypeOfEvent, RequiredCapacity, StartDateTime, EndDateTime, Student_ID, Lecturer_ID, VenueName, VenueCapacity, CategoryOfVenue, VenueLocation" +
                " FROM Booking b INNER JOIN Venue v ON b.VenueID = v.VenueID WHERE 1=1";
            List<OleDbParameter> parameters = new List<OleDbParameter>();

            
                // Build query based on the filter
                switch (cmbSearchFilters.SelectedItem.ToString())
                {
                    case "Date":
                        query += " AND b.StartDateTime >= @startDate AND b.EndDateTime <= @endDate";
                        parameters.Add(new OleDbParameter("@startDate", dtpStartDate.Value.Date));
                        parameters.Add(new OleDbParameter("@endDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1)));  // Include end of day
                        break;

                    case "Capacity":
                        query += " AND b.RequiredCapacity BETWEEN @minCapacity AND @maxCapacity";
                        parameters.Add(new OleDbParameter("@minCapacity", nudMinCapacity.Value));
                        parameters.Add(new OleDbParameter("@maxCapacity", nudMaxCapacity.Value));
                        break;

                    case "User ID":
                            if (cmbUserType.SelectedItem.ToString() == "Student")
                            {
                                query += " AND b.Student_ID = @userID";
                            }
                            else if (cmbUserType.SelectedItem.ToString() == "Lecturer")
                            {
                                query += " AND b.Lecturer_ID = @userID";
                            }
                            parameters.Add(new OleDbParameter("@userID", txtUserID.Text));
                            break;


                    case "Venue Name":
                        query += " AND v.VenueName LIKE @venueName";
                        parameters.Add(new OleDbParameter("@venueName", "%" + txtVenueName.Text + "%"));
                        break;

                case "Duration":
                    // Filter by duration, calculating the difference in hours between StartDateTime and EndDateTime
                    query += " AND DATEDIFF('h', b.StartDateTime, b.EndDateTime) = @duration";
                    parameters.Add(new OleDbParameter("@duration", (int)nudDuration.Value));  // Get duration from NumericUpDown
                    break;


            }
                
                    
            
                // Fetch data from the database
                return ExecuteQuery(query, parameters);
            
        }

        private void FilterAndDisplayBookings(DataTable dtBookings)
        {
            DataTable dtActiveBookings = dtBookings.Clone();
            DataTable dtPastBookings = dtBookings.Clone();

            foreach (DataRow row in dtBookings.Rows)
            {
                DateTime endDateTime = Convert.ToDateTime(row["EndDateTime"]);
                if (endDateTime < DateTime.Now)
                {
                    dtPastBookings.ImportRow(row);
                }
                else
                {
                    dtActiveBookings.ImportRow(row);
                }
            }

            // Display in the respective DataGridViews
            dgvActiveBookings.DataSource = dtActiveBookings;
            dgvPastBookings.DataSource = dtPastBookings;

            // Color the past bookings (gray out)
            foreach (DataGridViewRow pastRow in dgvPastBookings.Rows)
            {
                pastRow.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }
        private DataTable ExecuteQuery(string query, List<OleDbParameter> parameters)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }


       
        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = FormInput(blnValidInput);
            if (blnValidInput == true)
            {
                DataTable dtBookings = LoadBookings();
                FilterAndDisplayBookings(dtBookings); // Handles separating and displaying the bookings
            }
        }


        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this booking?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                if (dgvActiveBookings.CurrentRow != null)    // Ensure that there is a current row selected
                {
                    //int bookingId = Convert.ToInt32(dgvBookings.CurrentRow.Cells["Booking_ID"].Value); // Get the booking ID from the current row
                    // Retrieve StartDateTime as string
                    string startDateTimeString = dgvActiveBookings.CurrentRow.Cells["StartDateTime"].Value.ToString();
                    DateTime startDateTime;
                    if (DateTime.TryParse(startDateTimeString, out startDateTime))  // Parse StartDateTime string into a DateTime object
                    {
                        // Check if the booking is in the past
                        if (startDateTime < DateTime.Now)
                        {
                            MessageBox.Show("You cannot delete past bookings.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Get the Booking ID from the selected row
                            int bookingId = Convert.ToInt32(dgvActiveBookings.CurrentRow.Cells["Booking_ID"].Value);

                            // Call your delete method
                            DeleteBooking(bookingId, startDateTime);

                            // Refresh the GridView after deletion
                            DataTable dtBookings = LoadBookings();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Could not parse the booking start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void DeleteBooking(int bookingId, DateTime startDateTime)
        {
            DateTime currentDateTime = DateTime.Now;
            // Check if the booking is more than 2 days in the future
            if (startDateTime < currentDateTime.AddDays(1))
            {
                MessageBox.Show("You can only delete bookings at least 1 day in advance.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deleteQuery = "DELETE FROM Booking WHERE Booking_ID = ?";  // Define the delete query

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", bookingId);  // Add the Booking_ID parameter
                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Execute the delete command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: Booking not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Close the connection
                        conn.Close();
                    }
                }
            }
        }
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            AdminMainMenuPage adminMainMenuPage = new AdminMainMenuPage();
            this.Visible = false;
            adminMainMenuPage.ShowDialog();
        }

        private void dgvActiveBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Check if the search filter is set to "User ID"
            if (cmbSearchFilters.SelectedItem != null && cmbSearchFilters.SelectedItem.ToString() == "User ID")
            {
                // Check if the clicked column is the "Actions" column and the click is within valid row bounds
                if (e.ColumnIndex == dgvActiveBookings.Columns["Actions"].Index && e.RowIndex >= 0)
                {
                    
                        // Select the clicked row
                        dgvActiveBookings.CurrentCell = dgvActiveBookings.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        // Enable update and delete options in the context menu
                        updateToolStripMenuItem.Enabled = true;
                        dToolStripMenuItem.Enabled = true;

                        // Show the context menu at the cursor position
                        contextMenuStrip1.Show(Cursor.Position);
                    
                }
            }
            else
            {
                // If the search filter is not "User ID", disable the context menu options
                updateToolStripMenuItem.Enabled = false;
                dToolStripMenuItem.Enabled = false;
            }
        }
    }
}