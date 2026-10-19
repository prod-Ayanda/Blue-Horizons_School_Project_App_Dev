// =============================================================================
// Models/Invoice.cs
// A financial record generated after a booking is confirmed.
// =============================================================================

using System;

namespace PROJECTT.Models
{
    /// <summary>
    /// Represents a tax/payment invoice linked to a confirmed booking.
    /// Invoices are read-only once issued.
    /// </summary>
    public class Invoice
    {
        /// <summary>Sequential or GUID-based invoice reference number.</summary>
        public string InvoiceNo { get; set; }

        /// <summary>Foreign key – references Booking.BookingID.</summary>
        public string BookingID { get; set; }

        /// <summary>Foreign key – references User.UserID (for quick lookups).</summary>
        public string UserID { get; set; }

        /// <summary>Date the invoice was generated.</summary>
        public DateTime IssueDate { get; set; }

        /// <summary>Free-text summary of what was booked (activity name, participants, etc.).</summary>
        public string Details { get; set; }

        /// <summary>Grand total amount billed in ZAR.</summary>
        public decimal Total { get; set; }
    }
}
