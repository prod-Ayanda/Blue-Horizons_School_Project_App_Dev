using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    public static class ContactService
    {
        public static event Action MessagesUpdated;

        private static string MessagesFilePath
        {
            get
            {
                FileService.EnsureDataFolder();
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "contact_messages.txt");
            }
        }

        private static void EnsureSeedMessages()
        {
            string path = MessagesFilePath;
            if (File.Exists(path)) return;

            var seed = new List<ContactMessage>
            {
                new ContactMessage
                {
                    Id = 1,
                    Name = "Sipho Dlamini",
                    Email = "sipho.dlamini@gmail.com",
                    Subject = "Private Group Safari Inquiry",
                    Message = "Hi Blue Horizon team, we have a group of 8 visiting next month and would love to book the Big Five Sunrise Safari together.",
                    IsRead = false,
                    DateSent = DateTime.Now.AddHours(-5)
                },
                new ContactMessage
                {
                    Id = 2,
                    Name = "Lerato Mokoena",
                    Email = "lerato.m@outlook.com",
                    Subject = "Ticket PDF & Dietary Question",
                    Message = "Thank you for the PDF tickets! Does the Night Safari & Bush Braai include vegetarian options?",
                    IsRead = true,
                    DateSent = DateTime.Now.AddDays(-1)
                }
            };
            SaveAllInternal(seed);
        }

        private static string Escape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\").Replace("|", "&#124;").Replace("\r", "").Replace("\n", "\\n");
        }

        private static string Unescape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\n", Environment.NewLine).Replace("&#124;", "|").Replace("\\\\", "\\");
        }

        private static void SaveAllInternal(List<ContactMessage> list)
        {
            var sb = new StringBuilder();
            foreach (var m in list)
            {
                sb.AppendLine(string.Join("|", new[]
                {
                    m.Id.ToString(CultureInfo.InvariantCulture),
                    Escape(m.Name),
                    Escape(m.Email),
                    Escape(m.Subject),
                    Escape(m.Message),
                    m.IsRead ? "1" : "0",
                    m.DateSent.ToString("o", CultureInfo.InvariantCulture)
                }));
            }
            File.WriteAllText(MessagesFilePath, sb.ToString(), Encoding.UTF8);
        }

        public static List<ContactMessage> GetAllMessages()
        {
            EnsureSeedMessages();
            var list = new List<ContactMessage>();
            string path = MessagesFilePath;
            if (!File.Exists(path)) return list;

            foreach (string raw in File.ReadAllLines(path, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                string[] parts = raw.Split('|');
                if (parts.Length < 7) continue;

                int id = 0;
                int.TryParse(parts[0], out id);
                DateTime dt = DateTime.Now;
                DateTime.TryParse(parts[6], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt);

                list.Add(new ContactMessage
                {
                    Id = id,
                    Name = Unescape(parts[1]),
                    Email = Unescape(parts[2]),
                    Subject = Unescape(parts[3]),
                    Message = Unescape(parts[4]),
                    IsRead = parts[5] == "1" || string.Equals(parts[5], "true", StringComparison.OrdinalIgnoreCase),
                    DateSent = dt
                });
            }

            return list.OrderByDescending(m => m.DateSent).ToList();
        }

        public static bool SaveMessage(string name, string email, string subject, string message)
        {
            try
            {
                var list = GetAllMessages();
                int nextId = list.Count == 0 ? 1 : list.Max(m => m.Id) + 1;
                list.Add(new ContactMessage
                {
                    Id = nextId,
                    Name = name ?? "",
                    Email = email ?? "",
                    Subject = string.IsNullOrWhiteSpace(subject) ? "General Inquiry" : subject,
                    Message = message ?? "",
                    IsRead = false,
                    DateSent = DateTime.Now
                });
                SaveAllInternal(list);
                MessagesUpdated?.Invoke();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void MarkAsRead(int messageId)
        {
            try
            {
                var list = GetAllMessages();
                bool changed = false;
                foreach (var m in list)
                {
                    if (m.Id == messageId && !m.IsRead)
                    {
                        m.IsRead = true;
                        changed = true;
                    }
                }
                if (changed)
                {
                    SaveAllInternal(list);
                    MessagesUpdated?.Invoke();
                }
            }
            catch { }
        }
    }
}
