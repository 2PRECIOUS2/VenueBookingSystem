using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueBookingSystem
{
    internal class Venue
    {
        public int VenueID { get; set; }        // Represents the VenueID from the database
        public string VenueName { get; set; }   // Represents the VenueName from the database
        public string VenueLocation { get; set; }   // Represents the VenueLocation
        public int Capacity { get; set; }       // Represents the VenueCapacity
        public string VenueType { get; set; }
    }
}
