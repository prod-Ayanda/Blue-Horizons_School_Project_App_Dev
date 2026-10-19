using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PROJECTT.Services
{
    /// <summary>
    /// Validation, ZAR Currency Formatter, Luhn Card Check, and Ticket Number Generator
    /// incorporated from Tourist/Booking.cs and Tourist/BookingService.cs.
    /// </summary>
    public static class BookingService
    {
        public static event Action BookingCompleted;
        public static void NotifyBookingCompleted() => BookingCompleted?.Invoke();

        public static readonly Regex NameRx  = new Regex(@"^\p{L}[\p{L} '.\-]{1,59}$", RegexOptions.Compiled);
        public static readonly Regex EmailRx = new Regex(@"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9\-]+(\.[A-Za-z0-9\-]+)*\.[A-Za-z]{2,}$", RegexOptions.Compiled);
        public static readonly Regex CardRx  = new Regex(@"^\d{13,19}$", RegexOptions.Compiled);
        public static readonly Regex MonthRx = new Regex(@"^(0?[1-9]|1[0-2])$", RegexOptions.Compiled);
        public static readonly Regex YearRx  = new Regex(@"^(\d{2}|\d{4})$", RegexOptions.Compiled);
        public static readonly Regex CvcRx   = new Regex(@"^\d{3,4}$", RegexOptions.Compiled);

        public static string FormatZar(decimal v)
        {
            CultureInfo customZa = (CultureInfo)new CultureInfo("en-ZA").Clone();
            customZa.NumberFormat.CurrencySymbol = "R";
            customZa.NumberFormat.CurrencyPositivePattern = 2;   // R 1 250,00
            customZa.NumberFormat.CurrencyNegativePattern = 12;  // -R 1 250,00
            customZa.NumberFormat.CurrencyGroupSeparator = " ";
            customZa.NumberFormat.CurrencyDecimalSeparator = ",";
            return v.ToString("C", customZa);
        }

        public static string CheckName(string name)
        {
            return NameRx.IsMatch((name ?? "").Trim())
                ? null
                : "Enter your full name (letters only, at least 2).";
        }

        public static string CheckEmail(string email)
        {
            return EmailRx.IsMatch((email ?? "").Trim())
                ? null
                : "Enter a valid email, like name@example.com.";
        }

        public static string CheckCard(string rawCard)
        {
            string card = (rawCard ?? "").Replace(" ", "").Replace("-", "").Trim();
            if (!CardRx.IsMatch(card)) return "Card number must be 13 to 19 digits.";
            if (!PassesLuhn(card)) return "This card number is not valid.";
            return null;
        }

        public static string CheckExpiry(string rawMonth, string rawYear)
        {
            string m = (rawMonth ?? "").Trim();
            string y = (rawYear ?? "").Trim();
            if (!MonthRx.IsMatch(m)) return "Month must be 1 to 12.";
            if (!YearRx.IsMatch(y)) return "Year must be 2 or 4 digits.";

            int month = int.Parse(m), year = int.Parse(y);
            if (year < 100) year += 2000;
            if (year > DateTime.Today.Year + 20) return "That year is too far ahead.";
            if (new DateTime(year, month, 1).AddMonths(1) <= DateTime.Today) return "This card has expired.";
            return null;
        }

        public static string CheckCvc(string rawCvc)
        {
            return CvcRx.IsMatch((rawCvc ?? "").Trim())
                ? null
                : "CVC must be 3 or 4 digits.";
        }

        public static bool PassesLuhn(string digits)
        {
            if (string.IsNullOrEmpty(digits) || digits.Length < 13 || digits.Length > 19) return false;
            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(digits[i])) return false;
                int d = digits[i] - '0';
                if (alt)
                {
                    d *= 2;
                    if (d > 9) d -= 9;
                }
                sum += d;
                alt = !alt;
            }
            return sum % 10 == 0;
        }

        public static List<string> GenerateTicketNumbers(int bookingSequence, int guests)
        {
            var list = new List<string>();
            int seq = Math.Max(1, bookingSequence);
            for (int i = 1; i <= guests; i++)
            {
                string ticketNo = string.Format(
                    "BH-{0:D6}-{1:D2}-{2}",
                    seq,
                    i,
                    Guid.NewGuid().ToString("N").Substring(0, 4).ToUpperInvariant());
                list.Add(ticketNo);
            }
            return list;
        }
    }
}
