using System;

namespace PROJECTT
{
    /// <summary>
    /// Holds the admin passkey, the single admin account and the current role.
    /// There is only ONE admin, so the credentials live in variables here
    /// instead of a text file. Visitors are still read from Visitor.txt.
    /// </summary>
    internal static class AdminSession
    {
        // ---- Change these two lines to change the admin account ----
        public const string AdminEmail = "admin@blue.co.za";
        public const string AdminPassword = "Admin@123";

        // The passkey the admin has to type on the Welcome form.
        public const string AdminPasskey = "123456";

        // Admin emails must be South African company addresses.
        public const string RequiredEmailEnding = ".co.za";

        // How many tries the user gets at the passkey box.
        public const int MaxPasskeyAttempts = 3;

        // Set to true once the passkey box has been passed.
        public static bool PasskeyVerified = false;

        // Set to true once the admin has actually logged in.
        public static bool IsAdminLoggedIn = false;

        /// <summary>Length the passkey box should accept (taken from the passkey itself).</summary>
        public static int PasskeyLength
        {
            get { return AdminPasskey.Length; }
        }

        /// <summary>True only if the typed code matches the stored passkey exactly.</summary>
        public static bool IsPasskeyCorrect(string entered)
        {
            if (string.IsNullOrWhiteSpace(entered))
            {
                return false;
            }

            return entered.Trim() == AdminPasskey;
        }

        /// <summary>True only if the email ends with the required ending (e.g. .co.za).</summary>
        public static bool HasAllowedEmailEnding(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return email.Trim().EndsWith(RequiredEmailEnding, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>True only if the typed email and password match the stored admin account.</summary>
        public static bool AreAdminCredentialsCorrect(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            bool emailMatches = email.Trim().Equals(AdminEmail, StringComparison.OrdinalIgnoreCase);
            bool passwordMatches = password == AdminPassword;

            return emailMatches && passwordMatches;
        }

        /// <summary>Clears the role flags (call this on logout).</summary>
        public static void Reset()
        {
            PasskeyVerified = false;
            IsAdminLoggedIn = false;
        }
    }
}
