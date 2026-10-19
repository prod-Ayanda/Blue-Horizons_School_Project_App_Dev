// =============================================================================
// Models/Booking.cs
// Records a user's reservation for a specific activity.
// =============================================================================

using System;

namespace PROJECTT.Models
{
    /// <summary>
    /// Links a <see cref="User"/> to an <see cref="Activity"/> and tracks
    /// payment status and attendance.
    /// PaymentStatus values: "Pending" | "Paid" | "Cancelled"
    /// Attendance values   : "Pending" | "Attended" | "No-Show"
    /// </summary>
    public class Booking
    {
        /// <summary>Unique identifier (auto-generated GUID).</summary>
        public string BookingID { get; set; }

        /// <summary>Foreign key – references User.UserID.</summary>
        public string UserID { get; set; }

        /// <summary>Foreign key – references Activity.ActivityID.</summary>
        public string ActivityID { get; set; }

        /// <summary>Date and time the booking was created.</summary>
        public DateTime BookingDate { get; set; }

        /// <summary>Number of people included in this booking.</summary>
        public int ParticipantCount { get; set; }

        /// <summary>Calculated cost: ParticipantCount × Activity.Price.</summary>
        public decimal TotalCost { get; set; }

        /// <summary>Payment status: Pending | Paid | Cancelled.</summary>
        public string PaymentStatus { get; set; }

        /// <summary>Attendance status: Pending | Attended | No-Show.</summary>
        public string Attendance { get; set; }
    }
}
