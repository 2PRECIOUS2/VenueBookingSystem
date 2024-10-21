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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace VenueBookingSystem
{
    public partial class UpdateBooking : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public UpdateBooking()
        {
            InitializeComponent();
        }

        private int bookingId;
        private int originalCapacity;
        private DateTime originalStartDate;
        private DateTime originalEndDate;
        private string originalVenueID;

        public UpdateBooking(int bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;

            // Load the booking details based on t he passed booking ID
            //LoadBookingDetails(bookingId);
        }

        private void LoadBookingDetails(int bookingId)
        {
            string query = "SELECT b.TypeOfEvent, b.RequiredCapacity, b.StartDateTime, b.EndDateTime, " +
                           "v.VenueID, v.VenueName, v.VenueCapacity, v.CategoryOfVenue, v.VenueLocation " +
                           "FROM [Booking] b " +
                           "INNER JOIN [Venue] v ON b.VenueID = v.VenueID " +
                           "WHERE b.Booking_ID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", bookingId);

                    try
                    {
                        conn.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the Capacity and Date fields
                                nudCapacity.Value = Convert.ToInt32(reader["RequiredCapacity"]);
                                dateTimeStart.Value = reader["StartDateTime"] != DBNull.Value ? Convert.ToDateTime(reader["StartDateTime"]) : DateTime.Now;
                                dateTimeEnd.Value = reader["EndDateTime"] != DBNull.Value ? Convert.ToDateTime(reader["EndDateTime"]) : DateTime.Now;

                                // Populate the Type of Event label
                                lblTypeOfEvent.Text = reader["TypeOfEvent"].ToString();
                                lblCategoryOfVenue.Text = reader["CategoryOfVenue"].ToString();

                                originalCapacity = Convert.ToInt32(reader["RequiredCapacity"]);
                                originalStartDate = Convert.ToDateTime(reader["StartDateTime"]);
                                originalEndDate = Convert.ToDateTime(reader["EndDateTime"]);
                                originalVenueID = reader["VenueID"].ToString();

                                // Store the venue details in an object
                                var bookedVenue = new
                                {
                                    VenueID = reader["VenueID"].ToString(),
                                    VenueName = reader["VenueName"].ToString(),
                                    VenueLocation = reader["VenueLocation"].ToString(),
                                    VenueCapacity = Convert.ToInt32(reader["VenueCapacity"])
                                };

                                // Display the venue details in the form as labels (ID, Name, Capacity, Location)
                                lblVenueID.Text = bookedVenue.VenueID;
                                lblVenueName.Text = bookedVenue.VenueName;
                                lBLVenueCapacity.Text = bookedVenue.VenueCapacity.ToString();
                                lblVenueLocation.Text = bookedVenue.VenueLocation;

                                // Clear and add the booked venue to the ComboBox
                                cmbVenues.Items.Clear();
                                cmbVenues.DisplayMember = "DisplayText";
                                cmbVenues.ValueMember = "VenueID";
                                cmbVenues.Items.Add(new
                                {
                                    bookedVenue.VenueID,
                                    DisplayText = $"{bookedVenue.VenueID} - {bookedVenue.VenueName} - {bookedVenue.VenueLocation} (Capacity: {bookedVenue.VenueCapacity})"
                                });

                                cmbVenues.SelectedIndex = 0; // Pre-select the current venue
                            }
                            else
                            {
                                MessageBox.Show("No booking found for the given ID.");
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
            }
        }

        private void UpdateBooking_Load(object sender, EventArgs e)
        {
            LoadBookingDetails(this.bookingId);
          
        }

        private bool IsVenueAvailableForDates(string venueID, DateTime start, DateTime end)
        {
            string query = "SELECT COUNT(*) FROM [Booking] WHERE VenueID = ? " +
                           "AND (StartDateTime < ? AND EndDateTime > ?)";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", venueID);
                    cmd.Parameters.AddWithValue("?", end);
                    cmd.Parameters.AddWithValue("?", start);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count == 0; // True if no bookings found for the time range
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // Helper method to get the venue's capacity based on the venue ID
        private int GetVenueCapacity(string venueID)
        {
            string query = "SELECT VenueCapacity FROM [Venue] WHERE VenueID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", venueID);

                    try
                    {
                        conn.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return -1; // Return -1 if there's an error
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private bool IsVenueAvailable(string venueID, DateTime startDateTime, DateTime endDateTime, int bookingID)
        {
            bool isAvailable = false;

            string query = @"SELECT COUNT(*) FROM Booking 
                     WHERE VenueID = @VenueID 
                     AND Booking_ID <> @BookingID
                     AND ((@StartDateTime < EndDateTime AND @EndDateTime > StartDateTime))";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);
                cmd.Parameters.AddWithValue("@BookingID", bookingID); // Exclude the current booking ID from the check
                cmd.Parameters.AddWithValue("@StartDateTime", startDateTime);
                cmd.Parameters.AddWithValue("@EndDateTime", endDateTime);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    isAvailable = (count == 0); // Venue is available if no conflicting bookings are found
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking venue availability: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

            return isAvailable;
        }

        private bool IsCapacityValid(string venueID, int updatedCapacity)
        {
            bool isValid = false;

            string query = "SELECT VenueCapacity FROM Venue WHERE VenueID = @VenueID";

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@VenueID", venueID);

                try
                {
                    conn.Open();
                    int venueCapacity = (int)cmd.ExecuteScalar();
                    isValid = (updatedCapacity <= venueCapacity);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking venue capacity: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

            return isValid;
        }



        private bool ValidBookingDate(bool blnValidDate)
        {
            // Retrieve selected dates and times from the DateTimePicker controls
            DateTime startDateTime = dateTimeStart.Value.Date;
            DateTime endDateTime = dateTimeEnd.Value;
           

            // Combine the date and time into DateTime objects
          

            // Get the current date and time
            DateTime currentDateTime = DateTime.Now;

            // Check if the start date/time is in the past
            if (startDateTime < currentDateTime)
            {
                blnValidDate = false;
                MessageBox.Show("Start date and time cannot be in the past.", "Invalid Start Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return blnValidDate; // Stop further validation
            }

            // Check if the end date/time is before the start date/time
            if (endDateTime <= startDateTime)
            {
                blnValidDate = false;
                MessageBox.Show("End date and time must be after the start date and time.", "Invalid End Date/Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return blnValidDate; // Stop further validation
            }

            // If all validations pass
            blnValidDate = true;
            return blnValidDate;
        }

        private void UpdateBookingDetails()
        {
            int bookingID = this.bookingId;
            string selectedVenueID = cmbVenues.SelectedValue != null ? cmbVenues.SelectedValue.ToString() : originalVenueID;
            DateTime newStartDateTime = dateTimeStart.Value;
            DateTime newEndDateTime = dateTimeEnd.Value;
            int newCapacity = (int)nudCapacity.Value;

            // First, check if the new venue is available for the updated dates
            if (!IsVenueAvailable(selectedVenueID, newStartDateTime, newEndDateTime, bookingID))
            {
                MessageBox.Show("The selected venue is already booked for the specified dates.", "Venue Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Then, check if the new capacity does not exceed the venue's capacity
            if (!IsCapacityValid(selectedVenueID, newCapacity))
            {
                MessageBox.Show("The required capacity exceeds the venue's capacity.", "Capacity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            // Get the original values (initialized when form loaded)
            DateTime originalStartDateTime = originalStartDate;
            DateTime originalEndDateTime = originalEndDate;
            int originalRCapacity = originalCapacity;
            string originallVenueID = originalVenueID;

            // Initialize the query string
            string query = "UPDATE Booking SET ";
            List<string> updateFields = new List<string>();

            // Check if the capacity has changed
            if (newCapacity != originalCapacity)
            {
                updateFields.Add("RequiredCapacity = @Capacity");
            }

            // Check if the start or end date has changed
            if (newStartDateTime != originalStartDate || newEndDateTime != originalEndDate)
            {
                updateFields.Add("StartDateTime = @StartDateTime");
                updateFields.Add("EndDateTime = @EndDateTime");
            }

            // Check if the venue has changed
            if (!selectedVenueID.Equals(originalVenueID))
            {
                updateFields.Add("VenueID = @VenueID");
            }

            // If no changes were made, exit early
            if (updateFields.Count == 0)
            {
                MessageBox.Show("No changes were made.", "No Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add the changes to the query string
            query += string.Join(", ", updateFields) + " WHERE Booking_ID = @BookingID";

            // Execute the query
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // Add parameters for changed fields
                    if (updateFields.Contains("RequiredCapacity = @Capacity"))
                    {
                        cmd.Parameters.AddWithValue("@Capacity", newCapacity);
                    }

                    if (updateFields.Contains("StartDateTime = @StartDateTime"))
                    {
                        cmd.Parameters.AddWithValue("@StartDateTime", newStartDateTime);
                        cmd.Parameters.AddWithValue("@EndDateTime", newEndDateTime);
                    }

                    if (updateFields.Contains("VenueID = @VenueID"))
                    {
                        cmd.Parameters.AddWithValue("@VenueID", selectedVenueID);
                    }

                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            MyBookings myBookings = new MyBookings();  
                            myBookings.ShowDialog();
                            myBookings.Refresh();
                            // Return to the booking page or refresh the view
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the booking.", "No Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
                if (ValidBookingDate(true)) // Assuming this validates the dates
                {
                    UpdateBookingDetails();
                }
            
        }

            private void btnSelectVenue_Click(object sender, EventArgs e)
        {
            
                    string selectedCategory = lblCategoryOfVenue.Text;
                    int selectedCapacity = (int)nudCapacity.Value;
                    int minCapacity = selectedCapacity;
                    int maxCapacity = selectedCapacity + 30;
                    DateTime startDateTime = dateTimeStart.Value;
                    DateTime endDateTime = dateTimeEnd.Value;

            conn.Open();
            string query = @"SELECT v.VenueID, v.VenueName, v.VenueCapacity, v.VenueLocation
                         FROM Venue v
                         LEFT JOIN Booking b ON v.VenueID = b.VenueID
                         WHERE v.CategoryOfVenue = @Category
                         AND v.VenueCapacity >= @MinCapacity
                         AND v.VenueCapacity <= @MaxCapacity
                         AND (b.VenueID IS NULL OR NOT 
                             (@StartDateTime < b.EndDateTime AND @EndDateTime > b.StartDateTime))";


                           OleDbCommand command = new OleDbCommand(query, conn);
                        
                            command.Parameters.AddWithValue("@Category", selectedCategory);
                            command.Parameters.AddWithValue("@MinCapacity", minCapacity);
                            command.Parameters.AddWithValue("@MaxCapacity", maxCapacity);
                            command.Parameters.AddWithValue("@StartDateTime", startDateTime);
                            command.Parameters.AddWithValue("@EndDateTime", endDateTime);

                            try
                            {
                            
                                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                                DataTable Venue = new DataTable();
                                adapter.Fill(Venue);

                                if (Venue.Rows.Count > 0)
                                {
                                    Venue.Columns.Add("DisplayDetails", typeof(string), "VenueName + ' - Capacity: ' + VenueCapacity + ' - Location: ' + VenueLocation");
                                    cmbVenues.DataSource = Venue;
                                    cmbVenues.ValueMember = "VenueID";
                                    cmbVenues.DisplayMember = "DisplayDetails";
                                }
                                else
                                {
                                    MessageBox.Show("No available venues for the selected date and time or capacity.", "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                }
                            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}