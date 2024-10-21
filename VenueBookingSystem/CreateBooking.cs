using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VenueBookingSystem
{
    public partial class CreateBooking : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public CreateBooking()
        {
            InitializeComponent();
        }
        

        private bool ValidateFormInput(bool blnValidInput)
        {
            string selectedTypeOfEvent = cmbTypeOfEvent.SelectedItem?.ToString(); // Safeguard nulls
            if (string.IsNullOrEmpty(selectedTypeOfEvent))
            {
                blnValidInput = false;
                errorProvider1.SetError(cmbTypeOfEvent, "Please select the type of event");
            }

            string selectedCategory = cmbCategory.SelectedItem?.ToString(); // Safeguard nulls
            if (string.IsNullOrEmpty(selectedCategory))
            {
                blnValidInput = false;
                errorProvider1.SetError(cmbCategory, "Please select a category");
            }

            int selectedCapacity = (int)nudCapacity.Value;
            if (selectedCapacity <= 0)
            {
                blnValidInput = false;
                errorProvider1.SetError(nudCapacity, "Capacity must be above 1");

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



        private void btnCheckVenue_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            bool blnValidDate = true;
            blnValidDate = ValidateBookingDate(blnValidDate);
            blnValidInput = ValidateFormInput(blnValidInput);
            if (blnValidInput == true) {
                if (blnValidDate == true)
                {
                    {

                        string selectedCategory = cmbCategory.SelectedItem?.ToString();
                        int selectedCapacity = (int)nudCapacity.Value;
                        int minCapacity = selectedCapacity; // Set min to the selected capacity
                        int maxCapacity = selectedCapacity + 30;

                        DateTime startDate = dateStart.Value.Date;
                        DateTime endDate = dateEnd.Value.Date;
                        TimeSpan startTime = StartTime.Value.TimeOfDay;
                        TimeSpan endTime = EndTime.Value.TimeOfDay;

                        DateTime startDateTime = startDate.Add(startTime);
                        DateTime endDateTime = endDate.Add(endTime);
                        //MessageBox.Show($"Start: {startDate.Add(startTime)}\nEnd: {endDate.Add(endTime)}", "Debug Dates");




                        conn.Open();
                        string query = @"
           SELECT v.VenueID, v.VenueName, v.VenueCapacity, v.VenueLocation
           FROM Venue v
           LEFT JOIN Booking b ON v.VenueID = b.VenueID
           WHERE v.CategoryOfVenue = @Category
           AND v.VenueCapacity >= @MinCapacity 
           AND v.VenueCapacity <= @MaxCapacity
           AND (b.VenueID IS NULL OR NOT (
    (@StartDateTime < b.EndDateTime AND @EndDateTime > b.StartDateTime) 
    OR (@StartDateTime >= b.StartDateTime AND @EndDateTime <= b.EndDateTime) 
    OR (@StartDateTime <= b.StartDateTime AND @EndDateTime >= b.EndDateTime) 

                   )) ";

                        OleDbCommand command = new OleDbCommand(query, conn);

                        // Add parameters for category, capacity, and date/time range
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

                                cmbAvailableVenues.DataSource = Venue;
                                cmbAvailableVenues.ValueMember = "VenueID"; // What will be used internally
                                cmbAvailableVenues.DisplayMember = "DisplayDetails"; // What the user will see
                            }

                            else
                            {
                                MessageBox.Show("No available venues for the selected date and time.", "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                }
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            //Check if a venue is selected
            if (cmbAvailableVenues.SelectedItem == null)
            {
                MessageBox.Show("Please select a venue to book.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected venue ID and name
            int selectedVenueID = (int)cmbAvailableVenues.SelectedValue; 
            string selectedVenueName = cmbAvailableVenues.Text;


            DateTime startDate = dateStart.Value.Date;
            DateTime endDate = dateEnd.Value.Date;
            TimeSpan startTime = StartTime.Value.TimeOfDay;
            TimeSpan endTime = EndTime.Value.TimeOfDay;
            DateTime startDateTime = startDate.Add(startTime);
            DateTime endDateTime = endDate.Add(endTime);
            //Confirm the booking
            var result = MessageBox.Show($"Are you sure you want to book the venue '{selectedVenueName}'?",
                                           "Confirm Booking",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // If the user clicks 'No', exit the method
            }

            //Insert booking details into the database
            conn.Open();
                string query = @"
            INSERT INTO Booking (TypeOfEvent, RequiredCapacity, VenueID, StartDateTime, EndDateTime, Student_ID, Lecturer_ID) 
            VALUES (@TypeOfEvent, @RequiredCapacity, @VenueID, @StartDateTime, @EndDateTime, @Student_ID, @Lecturer_ID)";

                OleDbCommand command = new OleDbCommand(query, conn);

                // Add parameters
                command.Parameters.AddWithValue("@TypeOfEvent", cmbTypeOfEvent.Text);
                command.Parameters.AddWithValue("@RequiredCapacity", nudCapacity.Value);
                command.Parameters.AddWithValue("@VenueID", selectedVenueID);
                command.Parameters.AddWithValue("@StartDateTime", startDateTime);
                command.Parameters.AddWithValue("@EndDateTime", endDateTime);

                // Add Student_ID and Lecture_ID based on the user type
                if (Users.LoggedInUserType == "Student")
                {
                                        command.Parameters.AddWithValue("@Student_ID", Users.LoggedInUserID);
                    command.Parameters.AddWithValue("@Lecturer_ID", DBNull.Value); 
                }
                else if (Users.LoggedInUserType == "Lecturer")
                {
                command.Parameters.AddWithValue("@Student_ID", DBNull.Value);
                command.Parameters.AddWithValue("@Lecturer_ID", Users.LoggedInUserID);
                    // No Student ID for lecturers
                }


                try
                {
                    
                    command.ExecuteNonQuery(); // Execute the insert command
                    MessageBox.Show("Booking confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
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


        private void clear()
        {
            cmbCategory.SelectedIndex = -1;
            cmbTypeOfEvent.SelectedIndex = -1;
            cmbAvailableVenues.SelectedIndex = -1;
           
            nudCapacity.Value = 0;
            dateEnd.Value = DateTime.Now;
            dateStart.Value = DateTime.Now;
            StartTime.Value = DateTime.Now;
            EndTime.Value = DateTime.Now;
            cmbTypeOfEvent.Focus();
            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuPage mainMenuPage = new MainMenuPage();
            this.Visible  = false;
            mainMenuPage.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CreateBooking_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchEquipments_Click(object sender, EventArgs e)
        {

        }
    }
}
        

       
    

