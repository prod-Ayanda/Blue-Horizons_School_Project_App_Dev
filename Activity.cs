// =============================================================================
// Models/Activity.cs
// Represents a bookable tour activity offered by Blue Horizons Tours.
// =============================================================================

using System;

namespace PROJECTT.Models
{
    /// <summary>
    /// A single bookable activity (e.g. Safari, Hiking Trail, Adventure, Event).
    /// SeatsAvailable is decremented each time a booking is confirmed.
    /// </summary>
    public class Activity
    {
        /// <summary>Unique identifier (auto-generated GUID).</summary>
        public string ActivityID { get; set; }

        /// <summary>High-level grouping: Safari | Adventure | Event | Hiking Trail.</summary>
        public string Category { get; set; }

        /// <summary>Short, human-readable name of the activity.</summary>
        public string Name { get; set; }

        /// <summary>Full description shown on the booking screen.</summary>
        public string Description { get; set; }

        /// <summary>Price per participant in ZAR.</summary>
        public decimal Price { get; set; }

        /// <summary>Scheduled date/time of the activity.</summary>
        public DateTime Date { get; set; }

        /// <summary>Maximum number of participants this activity can accommodate.</summary>
        public int TotalSeats { get; set; }

        /// <summary>Remaining seats after confirmed bookings are applied.</summary>
        public int SeatsAvailable { get; set; }
    }
}
