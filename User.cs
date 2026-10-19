// =============================================================================
// Models/User.cs
// Represents a registered user (visitor) or admin of the system.
// =============================================================================

namespace PROJECTT.Models
{
    /// <summary>
    /// Stores all personal and security details for a single system user.
    /// Role is either "Admin" or "User".
    /// PasswordHash holds the salted SHA-256 hash; salt is stored inline.
    /// </summary>
    public class User
    {
        /// <summary>Unique identifier (auto-generated GUID).</summary>
        public string UserID { get; set; }

        /// <summary>User's first name.</summary>
        public string FirstName { get; set; }

        /// <summary>User's last name / surname.</summary>
        public string LastName { get; set; }

        /// <summary>Email address – used as the login credential.</summary>
        public string Email { get; set; }

        /// <summary>Contact phone number.</summary>
        public string Phone { get; set; }

        /// <summary>Gender (e.g. Male, Female, Other).</summary>
        public string Gender { get; set; }

        /// <summary>
        /// Salted SHA-256 hash stored as "salt:hash" so each account
        /// has a unique cryptographic fingerprint even if passwords match.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>Access role: "Admin" or "User".</summary>
        public string Role { get; set; }
    }
}
