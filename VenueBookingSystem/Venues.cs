using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueBookingSystem
{
    internal class Venues
    {
        // Define a simple Venue class
        public class Venue
        {
            public int VenueID { get; set; }
            public string VenueName { get; set; }
            public int VenueCapacity { get; set; }
            public string VenueLocation { get; set; }

            // Override ToString() to display the venue name and capacity
            public override string ToString()
            {
                return $"{VenueName} - {VenueLocation} (Capacity: {VenueCapacity})";
            }
        }

    }
}
