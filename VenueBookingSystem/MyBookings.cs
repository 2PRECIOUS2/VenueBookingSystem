using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class MyBookings : Form
    {

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb");

        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\user\OneDrive\Documents\VenueBookingSystem.accdb";
        public MyBookings()
        {
            InitializeComponent();

        }

        private void MyBookings_Load(object sender, EventArgs e)
        {
            AddActionButtonsToGridView();
            LoadBookings(); // Load bookings when the form is loaded
            FormatBookings();
            CustomizeDataGridView();
            dgvBookings.CellContentClick += dgvBookings_CellContentClick;

        }

        private void LoadBookings()
        {
            DateTime currentDateTime = DateTime.Now;

            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                string bookingsQuery = @"
                      SELECT b.Booking_ID,b.TypeOfEvent, b.RequiredCapacity,v.VenueName,v.VenueLocation, v.VenueCapacity,
                       v.CategoryOfVenue,b.StartDateTime, b.EndDateTime,
                         IIf(B.EndDateTime < @currentDateTime, 'Past', 'Current') AS BookingStatus
                       FROM Booking b INNER JOIN  Venue v ON b.VenueID = v.VenueID
                       WHERE (b.Student_ID = @LoggedInUserID OR b.Lecturer_ID = @LoggedInUserID)"
                ;

                string currentDateTimeString = currentDateTime.ToString("MM/dd/yyyy HH:mm:ss");

                OleDbCommand cmd = new OleDbCommand(bookingsQuery, conn);
                cmd.Parameters.AddWithValue("@CurrentDateTime", currentDateTimeString);
                cmd.Parameters.AddWithValue("@LoggedInUserID", Users.LoggedInUserID);
                // cmd.Parameters.AddWithValue("?", Users.LoggedInUserID);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    da.Fill(dt);
                    dgvBookings.DataSource = dt;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void CustomizeDataGridView()
        {
            // Enable word wrapping for cell text
            dgvBookings.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Set row height to allow multiple lines of text
            dgvBookings.RowTemplate.Height = 80; // You can adjust this value as per your design
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Make all columns read-only
            foreach (DataGridViewColumn column in dgvBookings.Columns)
            {
                column.ReadOnly = true;
            }
            dgvBookings.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBookings.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void dgvBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBookings.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                DateTime startDateTime = Convert.ToDateTime(dgvBookings.Rows[e.RowIndex].Cells["StartDateTime"].Value);

                // If the booking is in the past, disable the update and delete options
                if (startDateTime < DateTime.Now)
                {
                    toolStripUpdate.Enabled = false;  // Disable update
                    deleteToolStripMenuItem.Enabled = false;  // Disable delete
                }
                else
                {
                    // Enable update and delete for future bookings
                    toolStripUpdate.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                }

                contextMenuStripBooking.Show(Cursor.Position);
                
            }
            }


        private void AddActionButtonsToGridView()
        {
            // Add the three dots button (Ellipsis) for actions
            DataGridViewButtonColumn ellipsisColumn = new DataGridViewButtonColumn();
            ellipsisColumn.Name = "Actions";
            ellipsisColumn.Text = "⋮";  // Three vertical dots
            ellipsisColumn.UseColumnTextForButtonValue = true;
            dgvBookings.Columns.Add(ellipsisColumn);

            // Handle click events for the ellipsis column
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            MainMenuPage mainMenu = new MainMenuPage();
            this.Visible = false;
            mainMenu.Show();

        }

        private void toolStripUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBookings.CurrentRow != null)
            {
                // Get the booking ID from the current row
                int bookingId = Convert.ToInt32(dgvBookings.CurrentRow.Cells["Booking_ID"].Value);

                // Open the update booking form and pass the booking ID
                UpdateBooking updateForm = new UpdateBooking(bookingId);
                updateForm.ShowDialog();  // Opens the form as a modal dialog
            }
            else
            {
                MessageBox.Show("No booking selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this booking?",
                          "Confirm Delete",
                          MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                if (dgvBookings.CurrentRow != null)    // Ensure that there is a current row selected
                {
                    //int bookingId = Convert.ToInt32(dgvBookings.CurrentRow.Cells["Booking_ID"].Value); // Get the booking ID from the current row
                    // Retrieve StartDateTime as string
                    string startDateTimeString = dgvBookings.CurrentRow.Cells["StartDateTime"].Value.ToString();
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
                            int bookingId = Convert.ToInt32(dgvBookings.CurrentRow.Cells["Booking_ID"].Value);

                            // Call your delete method
                            DeleteBooking(bookingId, startDateTime);

                            // Refresh the GridView after deletion
                            LoadBookings();
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
            if (startDateTime < currentDateTime.AddDays(2))
            {
                MessageBox.Show("You can only delete bookings at least 2 days in advance.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void FormatBookings()
        {
            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                // Assuming the StartDateTime column exists and you want to compare with the current time
                DateTime startDateTime = Convert.ToDateTime(row.Cells["StartDateTime"].Value);

                if (startDateTime < DateTime.Now)  // If the booking is in the past
                {
                    // Gray out the row for past bookings
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                    row.DefaultCellStyle.BackColor = Color.LightGray;

                    // Disable actions for the 'Actions' column (ellipses or buttons)
                    row.Cells["Actions"].ReadOnly = true;

                    // Optionally disable the context menu from being shown
                    row.Cells["Actions"].Style.SelectionForeColor = Color.Gray;
                    row.Cells["Actions"].Style.SelectionBackColor = Color.LightGray;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
