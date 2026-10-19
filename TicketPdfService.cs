using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    /// <summary>
    /// Generates printable A5 Landscape PDF tickets matching Tourist/TicketPdfService.cs
    /// without requiring external native NuGet DLLs.
    /// </summary>
    public static class TicketPdfService
    {
        public static byte[] CreateTicket(
            Activity ev,
            string holderName,
            string ticketNo,
            int ticketIndex,
            int ticketCount,
            decimal pricePaid)
        {
            string eventName = ev != null ? ev.Name : "Blue Horizon Safari Experience";
            string venue = ev != null ? ("Cape Town Reserve (" + ev.Category + ")") : "Cape Town, South Africa";
            string dateText = ev != null ? ev.Date.ToString("dddd, d MMMM yyyy", CultureInfo.InvariantCulture) : DateTime.Today.ToString("dddd, d MMMM yyyy");
            string priceStr = BookingService.FormatZar(pricePaid);

            // A5 Landscape: 595 x 420 pt
            var content = new StringBuilder();

            // Outer border box (margin 28pt -> x=28, y=28, w=539, h=364)
            content.AppendLine("0.6 0.6 0.6 RG 1.2 w");
            content.AppendLine("28 28 539 364 re S");

            // Top brand bar
            content.AppendLine("BT /F2 10 Tf 0.11 0.48 0.28 rg 48 360 Td (" + EscapePdf("BLUE HORIZON  |  EXPLORE SOUTH AFRICA") + ") Tj ET");

            // Event Name (24pt Bold)
            content.AppendLine("BT /F2 22 Tf 0.08 0.10 0.16 rg 48 326 Td (" + EscapePdf(eventName) + ") Tj ET");

            // Ticket metadata lines
            content.AppendLine("BT /F2 11 Tf 0.15 0.18 0.24 rg 48 292 Td (Venue: ) Tj /F1 11 Tf (" + EscapePdf(venue) + ") Tj ET");
            content.AppendLine("BT /F2 11 Tf 0.15 0.18 0.24 rg 48 272 Td (Date & time: ) Tj /F1 11 Tf (" + EscapePdf(dateText) + ") Tj ET");
            content.AppendLine("BT /F2 11 Tf 0.15 0.18 0.24 rg 48 252 Td (Ticket holder: ) Tj /F1 11 Tf (" + EscapePdf(holderName) + ") Tj ET");
            content.AppendLine("BT /F2 11 Tf 0.15 0.18 0.24 rg 48 232 Td (Ticket: ) Tj /F1 11 Tf (" + EscapePdf(ticketIndex + " of " + ticketCount) + ") Tj ET");
            content.AppendLine("BT /F2 11 Tf 0.15 0.18 0.24 rg 48 212 Td (Price paid: ) Tj /F1 11 Tf (" + EscapePdf(priceStr) + ") Tj ET");

            // Light grey box for TICKET NUMBER
            content.AppendLine("0.93 0.94 0.96 rg 48 118 499 72 re f");
            content.AppendLine("BT /F2 9 Tf 0.35 0.38 0.44 rg 62 168 Td (" + EscapePdf("TICKET NUMBER") + ") Tj ET");
            content.AppendLine("BT /F2 22 Tf 0.06 0.09 0.15 rg 62 136 Td (" + EscapePdf(ticketNo) + ") Tj ET");

            // Entrance note
            content.AppendLine("BT /F1 9.5 Tf 0.35 0.38 0.44 rg 48 86 Td (" + EscapePdf("Present this ticket at the entrance. One ticket admits one guest.") + ") Tj ET");

            return BuildPdfBytes(content.ToString(), 595, 420);
        }

        public static string SaveCopies(List<string> ticketNos, List<byte[]> pdfs)
        {
            string docsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Blue Horizon Tickets");
            string appFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Tickets");

            try
            {
                Directory.CreateDirectory(docsFolder);
                for (int i = 0; i < pdfs.Count; i++)
                {
                    File.WriteAllBytes(Path.Combine(docsFolder, "Ticket-" + ticketNos[i] + ".pdf"), pdfs[i]);
                }
            }
            catch { }

            try
            {
                Directory.CreateDirectory(appFolder);
                for (int i = 0; i < pdfs.Count; i++)
                {
                    File.WriteAllBytes(Path.Combine(appFolder, "Ticket-" + ticketNos[i] + ".pdf"), pdfs[i]);
                }
            }
            catch { }

            return Directory.Exists(docsFolder) ? docsFolder : appFolder;
        }

        private static string EscapePdf(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c == '(' || c == ')' || c == '\\')
                    sb.Append('\\').Append(c);
                else if (c >= 32 && c <= 126)
                    sb.Append(c);
                else if (c == '–' || c == '—')
                    sb.Append('-');
                else
                    sb.Append(' ');
            }
            return sb.ToString();
        }

        private static byte[] BuildPdfBytes(string streamContent, int pageW, int pageH)
        {
            byte[] streamBytes = Encoding.ASCII.GetBytes(streamContent);
            var objects = new List<string>
            {
                "1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n",
                "2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n",
                $"3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {pageW} {pageH}] /Resources << /Font << /F1 4 0 R /F2 5 0 R >> >> /Contents 6 0 R >>\nendobj\n",
                "4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n",
                "5 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >>\nendobj\n",
                $"6 0 obj\n<< /Length {streamBytes.Length} >>\nstream\n{streamContent}endstream\nendobj\n"
            };

            using (var ms = new MemoryStream())
            {
                void WriteAscii(string s)
                {
                    byte[] b = Encoding.ASCII.GetBytes(s);
                    ms.Write(b, 0, b.Length);
                }

                WriteAscii("%PDF-1.4\n");
                var offsets = new List<long>();
                foreach (string obj in objects)
                {
                    offsets.Add(ms.Position);
                    WriteAscii(obj);
                }
                long xrefPos = ms.Position;
                WriteAscii($"xref\n0 {objects.Count + 1}\n");
                WriteAscii("0000000000 65535 f \n");
                foreach (long off in offsets)
                {
                    WriteAscii(off.ToString("D10", CultureInfo.InvariantCulture) + " 00000 n \n");
                }
                WriteAscii($"trailer\n<< /Size {objects.Count + 1} /Root 1 0 R >>\nstartxref\n{xrefPos}\n%%EOF");
                return ms.ToArray();
            }
        }
    }
}
