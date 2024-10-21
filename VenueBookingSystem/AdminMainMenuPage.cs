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
    public partial class AdminMainMenuPage : Form
    {
        public AdminMainMenuPage()
        {
            InitializeComponent();
        }

        private void manageProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProfiles manageProfiles = new ManageProfiles();
            this.Visible = false;
            manageProfiles.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            this.Visible = false;
            homepage.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageVenuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageVenues manageVenues = new ManageVenues();
            this.Visible = false;
            manageVenues.ShowDialog();
        }

        private void monitorBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonitorBokings monitorBokings = new MonitorBokings();
            this.Visible = false;
            monitorBokings.ShowDialog();
        }
    }
}
