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
    public partial class RecurringBooking : Form
    {
        public RecurringBooking()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";

        private bool ValidateFormInput(bool blnValidInput)
        {
            errorProvider1.Clear();
            string selectedTypeOfEvent = cmbTypeOfEvent.SelectedItem?.ToString(); // Safeguard nulls
            if (string.IsNullOrEmpty(selectedTypeOfEvent))
            {
                blnValidInput = false;
                errorProvider1.SetError(cmbTypeOfEvent, "Please select the type of event");
            }

            string selectedCategory = cmbCategoryOfVenue.SelectedItem?.ToString(); // Safeguard nulls
            if (string.IsNullOrEmpty(selectedCategory))
            {
                blnValidInput = false;
                errorProvider1.SetError(cmbCategoryOfVenue, "Please select a category");
            }

            int selectedCapacity = (int)nudRequiredCapacity.Value;
            if (selectedCapacity <= 0)
            {
                blnValidInput = false;
                errorProvider1.SetError(nudRequiredCapacity, "Capacity must be above 1");

            }

            if(radDaily.Checked == false && radWeekly.Checked == false)
            {
                blnValidInput |= false;
                errorProvider1.SetError(grpFrequencySelection, "Please choose whether you would like to make weelky or daily bookings");
            }
            if (radWeekly.Checked)
            {
                if (radMonday.Checked == false && radTuesday.Checked == false && radWed.Checked == false && radThur.Checked == false && radFriday.Checked == false && radSat.Checked == false && radSun.Checked == false)
                {
                    blnValidInput = false;
                    errorProvider1.SetError(grpReccurenceDays, "Please select the day(s) you would like to book for");
                }
            }
            return blnValidInput;
        }
        private bool ValidateBookingDate(bool blnValidDate)
        {
            // Retrieve selected dates and times from the DateTimePicker controls
            DateTime startDate = dateStart.Value.Date;
            DateTime startTime = StartTime.Value;
            DateTime endDate = dateEnd.Value.Date;
            DateTime endTime = EndTime.Value;

            DateTime currentDate = DateTime.Now;

            //Check if the start date/time is in the past
            DateTime startDateTime = startDate.Add(startTime.TimeOfDay);  // Combine date and time
            if (startDateTime < currentDate)
            {
                blnValidDate = false;
                MessageBox.Show("Start date and time cannot be in the past.", "Invalid Start Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //Check if the end date is before the start date
            if (endDate < startDate)
            {
                blnValidDate = false;
                MessageBox.Show("End date cannot be before the start date.", "Invalid End Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //Check if the end time is before the start time if the start and end dates are the same
            if (endDate == startDate && endTime.TimeOfDay <= startTime.TimeOfDay)
            {
                blnValidDate = false;
                MessageBox.Show("End time must be after the start time for the same day.", "Invalid End Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return blnValidDate;

        }

        private DayOfWeek GetSelectedDayFromGroupBox()
        {
            if(radMonday.Checked) return DayOfWeek.Monday;
            if (radTuesday.Checked) return DayOfWeek.Tuesday;
            if (radWed.Checked) return DayOfWeek.Wednesday;
            if (radThur.Checked) return DayOfWeek.Thursday;
            if (radFriday.Checked) return DayOfWeek.Friday;
            if (radSat.Checked) return DayOfWeek.Saturday;
            if (radSun.Checked) return DayOfWeek.Sunday;

            throw new Exception("No day selected.");
        }

        // Weekly recurrence
        List<DateTime> CalculateWeeklyRecurrence(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime)
        {
            List<DateTime> recurrenceDates = new List<DateTime>();
            DateTime currentDay = startDate;

            // Find the first occurrence of the selected day
            while (currentDay.DayOfWeek != dayOfWeek)
            {
                currentDay = currentDay.AddDays(1);
            }

            // Calculate recurrence
            while (currentDay <= endDate)
            {
                DateTime startBooking = currentDay.Date + startTime;
                DateTime endBooking = currentDay.Date + endTime;

                recurrenceDates.Add(startBooking);

                // Move to the next week
                currentDay = currentDay.AddDays(7);
            }

            return recurrenceDates;
        }

        // Daily recurrence
        List<DateTime> CalculateDailyRecurrence(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime)
        {
            List<DateTime> recurrenceDates = new List<DateTime>();
            DateTime currentDay = startDate;

            // Calculate daily recurrence
            while (currentDay <= endDate)
            {
                DateTime startBooking = currentDay.Date + startTime;
                DateTime endBooking = currentDay.Date + endTime;

                recurrenceDates.Add(startBooking);

                // Move to the next day
                currentDay = currentDay.AddDays(1);
            }

            return recurrenceDates;
        }


        private void btnSearchVenue_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            bool blnValidDate = true;
            blnValidDate = ValidateBookingDate(blnValidDate);
            blnValidInput = ValidateFormInput(blnValidInput);

            if (blnValidInput && blnValidDate)
            {
                string selectedCategory = cmbCategoryOfVenue.SelectedItem?.ToString();
                int selectedCapacity = (int)nudRequiredCapacity.Value;
                int minCapacity = selectedCapacity;
                int maxCapacity = selectedCapacity + 30;

                DateTime startDate = dateStart.Value.Date;
                DateTime endDate = dateEnd.Value.Date;
                TimeSpan startTime = StartTime.Value.TimeOfDay;
                TimeSpan endTime = EndTime.Value.TimeOfDay;

                List<DateTime> bookingDates = new List<DateTime>();

                if (radDaily.Checked)
                {
                    // Daily recurrence
                    bookingDates = CalculateDailyRecurrence(startDate, endDate, startTime, endTime);
                }
                else if (radWeekly.Checked)
                {
                    // Weekly recurrence
                    DayOfWeek selectedDay = GetSelectedDayFromGroupBox();
                    bookingDates = CalculateWeeklyRecurrence(startDate, endDate, selectedDay, startTime, endTime);
                }


                // Open connection and check availability for all calculated dates
                conn.Open();

                // Build query to check venue availability for each date in the list
                string query = @"
    SELECT v.VenueID, v.VenueName, v.VenueCapacity, v.VenueLocation
            FROM Venue v
            LEFT JOIN Booking b ON v.VenueID = b.VenueID
            WHERE v.CategoryOfVenue = @Category
            AND v.VenueCapacity >= @MinCapacity 
            AND v.VenueCapacity <= @MaxCapacity
            AND (b.VenueID IS NULL OR NOT (
                (@StartDateTime < b.EndDateTime AND @EndDateTime > b.StartDateTime)
            ))
                    ";

                // Prepare the SQL command
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.AddWithValue("@Category", selectedCategory);
                command.Parameters.AddWithValue("@MinCapacity", minCapacity);
                command.Parameters.AddWithValue("@MaxCapacity", maxCapacity);

                bool venueAvailableForAllDates = true;
                DataTable availableVenues = new DataTable();
                foreach (var bookingDate in bookingDates)
                {
                    // Set the start and end DateTime for the current bookingDate
                    DateTime currentStartDateTime = bookingDate.Add(startTime);
                    DateTime currentEndDateTime = bookingDate.Add(endTime);

                    // Clear only the dynamic parameters for the current date's time range
                    command.Parameters.Clear();

                    // Re-add static parameters that should be reused
                    command.Parameters.AddWithValue("@Category", selectedCategory);
                    command.Parameters.AddWithValue("@MinCapacity", minCapacity);
                    command.Parameters.AddWithValue("@MaxCapacity", maxCapacity);

                    // Add parameters for the current date's time range
                    command.Parameters.AddWithValue("@StartDateTime", currentStartDateTime);
                    command.Parameters.AddWithValue("@EndDateTime", currentEndDateTime);

                    try
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable venueResult = new DataTable();
                        adapter.Fill(venueResult);

                        // If no available venues found for this specific date, stop the process
                        if (venueResult.Rows.Count == 0)
                        {
                            venueAvailableForAllDates = false;
                            MessageBox.Show($"No available venues for the selected date and time: {currentStartDateTime.ToString("yyyy/MM/dd HH:mm")}.",
                                            "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            // If available, merge the results into a main DataTable
                            availableVenues.Merge(venueResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                conn.Close();

                // If venue is available for all dates, show them in the ComboBox
                if (venueAvailableForAllDates && availableVenues.Rows.Count > 0)
                {
                    availableVenues.Columns.Add("DisplayDetails", typeof(string), "VenueName + ' - Capacity: ' + VenueCapacity + ' - Location: ' + VenueLocation");

                    cmbAvailableVenues.DataSource = availableVenues;
                    cmbAvailableVenues.ValueMember = "VenueID"; // What will be used internally
                    cmbAvailableVenues.DisplayMember = "DisplayDetails"; // What the user will see
                }
                else
                {
                    MessageBox.Show("No available venues for the selected date range and time.",
                                    "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void InsertBooking(DateTime startDateTime, DateTime endDateTime)
        {
            // Check if a venue is selected
            if (cmbAvailableVenues.SelectedItem == null)
            {
                MessageBox.Show("Please select a venue to book.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected venue ID and name
            int selectedVenueID = (int)cmbAvailableVenues.SelectedValue;
            string selectedVenueName = cmbAvailableVenues.Text;

            // Get the event type and required capacity
            string typeOfEvent = cmbTypeOfEvent.Text;
            int requiredCapacity = (int)nudRequiredCapacity.Value;

            // Confirm the booking with the user
            var result = MessageBox.Show($"Are you sure you want to book the venue '{selectedVenueName}' on {startDateTime}?",
                                          "Confirm Booking",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // If the user clicks 'No', exit the method
            }

            // Insert booking details into the database
            string query = @"
    INSERT INTO Booking (TypeOfEvent, RequiredCapacity, StartDateTime, EndDateTime, Student_ID, Lecturer_ID, VenueID) 
    VALUES (@TypeOfEvent, @RequiredCapacity, @StartDateTime, @EndDateTime, @Student_ID, @Lecturer_ID, @VenueID)";

            using (OleDbConnection conn = new OleDbConnection(connectionstring)) // Ensure you use your actual connection string
            {
                using (OleDbCommand command = new OleDbCommand(query, conn))
                {
                    // Add parameters for the query
                    command.Parameters.AddWithValue("@TypeOfEvent", typeOfEvent);
                    command.Parameters.AddWithValue("@RequiredCapacity", requiredCapacity);
                    command.Parameters.AddWithValue("@StartDateTime", startDateTime);
                    command.Parameters.AddWithValue("@EndDateTime", endDateTime);

                    // Handle the user type and add Student_ID or Lecturer_ID
                    if (Users.LoggedInUserType == "Student")
                    {
                        command.Parameters.AddWithValue("@Student_ID", Users.LoggedInUserID);
                        command.Parameters.AddWithValue("@Lecturer_ID", DBNull.Value); // No lecturer ID for students
                    }
                    else if (Users.LoggedInUserType == "Lecturer")
                    {
                        command.Parameters.AddWithValue("@Student_ID", DBNull.Value); // No student ID for lecturers
                        command.Parameters.AddWithValue("@Lecturer_ID", Users.LoggedInUserID);
                    }

                    command.Parameters.AddWithValue("@VenueID", selectedVenueID);
                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Execute the query
                        command.ExecuteNonQuery();

                        // Display a success message
                        MessageBox.Show("Booking confirmed for " + startDateTime, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear the form after successful booking
                        clear();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors during the execution
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Close the connection if it's open
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if a venue is selected
            if (cmbAvailableVenues.SelectedItem == null)
            {
                MessageBox.Show("Please select a venue to book.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected venue ID and name
            int selectedVenueID = (int)cmbAvailableVenues.SelectedValue;
            string selectedVenueName = cmbAvailableVenues.Text;

            // Confirm booking
            var result = MessageBox.Show($"Are you sure you want to book the venue '{selectedVenueName}'?",
                                          "Confirm Booking",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; // Exit if the user doesn't confirm the booking
            }

            List<DateTime> bookingDates = new List<DateTime>();

            DateTime startDate = dateStart.Value.Date;
            DateTime endDate = dateEnd.Value.Date;
            TimeSpan startTime = StartTime.Value.TimeOfDay;
            TimeSpan endTime = EndTime.Value.TimeOfDay;

            if (radDaily.Checked)
            {
                // Daily recurrence
                bookingDates = CalculateDailyRecurrence(startDate, endDate, startTime, endTime);
            }
            else if (radWeekly.Checked)
            {
                // Weekly recurrence
                DayOfWeek selectedDay = GetSelectedDayFromGroupBox();
                bookingDates = CalculateWeeklyRecurrence(startDate, endDate, selectedDay, startTime, endTime);
            }

            foreach (var bookingDate in bookingDates)
            {
                DateTime currentStartDateTime = bookingDate.Add(startTime);
                DateTime currentEndDateTime = bookingDate.Add(endTime);
                InsertBooking(currentStartDateTime, currentEndDateTime);
            }
        }

            private void clear()
        {
            cmbCategoryOfVenue.SelectedIndex = -1;
            cmbTypeOfEvent.SelectedIndex = -1;
            cmbAvailableVenues.SelectedIndex = -1;

            nudRequiredCapacity.Value = 0;
            dateEnd.Value = DateTime.Now;
            dateStart.Value = DateTime.Now;
            StartTime.Value = DateTime.Now;
            EndTime.Value = DateTime.Now;
            cmbTypeOfEvent.Focus();

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuPage mainMenuPage = new MainMenuPage();
            this.Visible = false;
            mainMenuPage.ShowDialog();
        }

        private void radDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaily.Checked)
            {
                grpReccurenceDays.Enabled = false; // Disable day selection for daily booking
            }
        }

        private void radWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (radWeekly.Checked)
            {
                grpReccurenceDays.Enabled = true;  // Enable day selection for weekly booking
            }
        }

        private void RecurringBooking_Load(object sender, EventArgs e)
        {
            radDaily.CheckedChanged += new EventHandler(radWeekly_CheckedChanged);
            radWeekly.CheckedChanged += new EventHandler(radDaily_CheckedChanged);
        }
    }
}
