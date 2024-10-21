using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBookingSystem
{
    public partial class MainMenuPage : Form
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void MainMenuPage_Load(object sender, EventArgs e)
        {
        }
        


        private void makeAVenueBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to make a One-Time(Click Yes) or a Recurring Booking(Click No)?",
             "Select Booking Type",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question,
             MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes) // Yes represents One-Time Booking
            {
                // Open One-Time Booking Form
                CreateBooking oneTimeBookingForm = new CreateBooking();
                oneTimeBookingForm.ShowDialog(); // Or you can use .Show() based on your preference
            }
            else if (result == DialogResult.No) // No represents Recurring Booking
            {
                // Open Recurring Booking Form
                RecurringBooking recurringBookingForm = new RecurringBooking();
                recurringBookingForm.ShowDialog(); // Or use .Show()
            }
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            this.Visible = false;
            homepage.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyBookings myBookings = new MyBookings();
            this.Visible = false;
            myBookings.ShowDialog();
        }

        private void manageProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyProfile myProfile = new MyProfile();
            this.Visible = false;
            myProfile.ShowDialog();
        }
    }
}
