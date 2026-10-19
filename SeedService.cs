// =============================================================================
// Services/SeedService.cs
// Populates the data files with a default admin account and sample activities
// on the very first run (i.e. when users.txt and activities.txt are empty).
//
// The admin account (admin@bluehorizons.co.za) can ONLY be created here;
// self-registration is restricted to the "User" role.
// =============================================================================

using System;
using System.Collections.Generic;
using PROJECTT.Models;

namespace PROJECTT.Services
{
    /// <summary>
    /// Checks whether seed data already exists and, if not, writes the
    /// default admin user and 10 sample activities to their respective files.
    /// </summary>
    public static class SeedService
    {
        /// <summary>
        /// Entry point called from Program.Main.
        /// Safe to call every startup – it is a no-op if data already exists.
        /// </summary>
        public static void SeedIfEmpty()
        {
            SeedAdmin();
            SeedActivities();
        }

        // -----------------------------------------------------------------------
        // Admin seed
        // -----------------------------------------------------------------------

        /// <summary>
        /// Creates the single admin account if no admin already exists in users.txt.
        /// The admin email is hard-coded and cannot be registered through the UI.
        /// </summary>
        private static void SeedAdmin()
        {
            // Check whether an admin entry is already present.
            List<User> existing = FileService.GetAllUsers();
            foreach (User u in existing)
            {
                if (u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    return; // Admin already seeded – nothing to do.
            }

            // Create the default admin with a strong initial password.
            // Administrators should change this password on first login.
            var admin = new User
            {
                UserID       = Guid.NewGuid().ToString(),
                FirstName    = "Blue Horizons",
                LastName     = "Admin",
                Email        = AdminSession.AdminEmail,
                Phone        = "0210000000",
                Gender       = "N/A",
                PasswordHash = PasswordHelper.HashNewPassword(AdminSession.AdminPassword),
                Role         = "Admin"
            };

            FileService.AddUser(admin);
        }

        // -----------------------------------------------------------------------
        // Activities seed
        // -----------------------------------------------------------------------

        /// <summary>
        /// Inserts 10 sample activities (across Safari, Adventure, Event and
        /// Hiking Trail categories) if activities.txt is empty.
        /// </summary>
        private static void SeedActivities()
        {
            List<Activity> existing = FileService.GetAllActivities();
            if (existing.Count > 0)
                return; // Already seeded.

            // Base date – activities start from two weeks after seed time.
            DateTime baseDate = DateTime.Today.AddDays(14);

            var activities = new List<Activity>
            {
                // ── Safari ─────────────────────────────────────────────────────
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Safari",
                    Name           = "Big Five Sunrise Safari",
                    Description    = "Witness the Big Five at dawn in their natural habitat. " +
                                     "Includes a professional guide, open-top vehicle and breakfast.",
                    Price          = 1850.00m,
                    Date           = baseDate,
                    TotalSeats     = 12,
                    SeatsAvailable = 12
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Safari",
                    Name           = "Night Safari & Bush Braai",
                    Description    = "Explore the bush after dark with spotlight drives and " +
                                     "a traditional South African braai under the stars.",
                    Price          = 2200.00m,
                    Date           = baseDate.AddDays(3),
                    TotalSeats     = 10,
                    SeatsAvailable = 10
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Safari",
                    Name           = "Cape Winelands & Wildlife Drive",
                    Description    = "Combine a game drive through a private reserve with a " +
                                     "curated wine tasting at a boutique winery.",
                    Price          = 1650.00m,
                    Date           = baseDate.AddDays(5),
                    TotalSeats     = 16,
                    SeatsAvailable = 16
                },

                // ── Adventure ──────────────────────────────────────────────────
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Adventure",
                    Name           = "Abseil Table Mountain",
                    Description    = "Descend 112 metres down the face of Table Mountain with " +
                                     "certified instructors. All safety equipment provided.",
                    Price          = 950.00m,
                    Date           = baseDate.AddDays(2),
                    TotalSeats     = 20,
                    SeatsAvailable = 20
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Adventure",
                    Name           = "Shark Cage Diving – Gansbaai",
                    Description    = "Come face to face with great white sharks in a " +
                                     "supervised shark cage. Wetsuits and equipment included.",
                    Price          = 2400.00m,
                    Date           = baseDate.AddDays(7),
                    TotalSeats     = 8,
                    SeatsAvailable = 8
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Adventure",
                    Name           = "Dune Boarding – Atlantis Dunes",
                    Description    = "Race down towering sand dunes just outside Cape Town. " +
                                     "Boards, helmets and refreshments included.",
                    Price          = 750.00m,
                    Date           = baseDate.AddDays(4),
                    TotalSeats     = 25,
                    SeatsAvailable = 25
                },

                // ── Event ──────────────────────────────────────────────────────
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Event",
                    Name           = "Cape Town Jazz Festival Evening",
                    Description    = "VIP-package tickets to the renowned Cape Town Jazz Festival, " +
                                     "including backstage lounge access and dinner.",
                    Price          = 3100.00m,
                    Date           = baseDate.AddDays(10),
                    TotalSeats     = 30,
                    SeatsAvailable = 30
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Event",
                    Name           = "Sunset Cruise on the Atlantic",
                    Description    = "A luxurious two-hour catamaran cruise along the " +
                                     "Atlantic Seaboard with canapés and sparkling wine.",
                    Price          = 1200.00m,
                    Date           = baseDate.AddDays(6),
                    TotalSeats     = 18,
                    SeatsAvailable = 18
                },

                // ── Hiking Trail ────────────────────────────────────────────────
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Hiking Trail",
                    Name           = "Lion's Head Sunrise Hike",
                    Description    = "Summit Lion's Head at dawn for 360-degree panoramic views " +
                                     "of Cape Town, Table Mountain and the ocean. Guide included.",
                    Price          = 650.00m,
                    Date           = baseDate.AddDays(1),
                    TotalSeats     = 15,
                    SeatsAvailable = 15
                },
                new Activity
                {
                    ActivityID     = Guid.NewGuid().ToString(),
                    Category       = "Hiking Trail",
                    Name           = "Cape Point & Boulders Beach Trail",
                    Description    = "A full-day guided hike through Cape Point Nature Reserve, " +
                                     "ending with a visit to the famous penguin colony at Boulders Beach.",
                    Price          = 1100.00m,
                    Date           = baseDate.AddDays(9),
                    TotalSeats     = 20,
                    SeatsAvailable = 20
                }
            };

            // Write each activity to file.
            foreach (Activity activity in activities)
                FileService.AddActivity(activity);
        }
    }
}
