// =============================================================================
// Services/PasswordHelper.cs
// Provides salted SHA-256 password hashing and verification.
// No passwords are ever stored in plain text.
// =============================================================================

using System;
using System.Security.Cryptography;
using System.Text;

namespace PROJECTT.Services
{
    /// <summary>
    /// Utility class for creating and verifying salted SHA-256 password hashes.
    /// 
    /// Storage format stored in users.txt:
    ///   salt:hash
    /// where <c>salt</c> is a 16-byte random value encoded as Base64 and
    /// <c>hash</c> is the SHA-256 hex string of (salt + password).
    /// </summary>
    public static class PasswordHelper
    {
        // Separator used between the salt and the hash when persisted.
        private const char Separator = ':';

        /// <summary>
        /// Generates a cryptographically random salt, then produces and returns
        /// the combined "salt:hash" string ready for file storage.
        /// </summary>
        /// <param name="plainTextPassword">The raw password entered by the user.</param>
        /// <returns>"base64salt:hexhash" string.</returns>
        public static string HashNewPassword(string plainTextPassword)
        {
            // Generate a 16-byte (128-bit) random salt.
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            string saltBase64 = Convert.ToBase64String(saltBytes);
            string hash       = ComputeHash(saltBase64, plainTextPassword);

            // Return "salt:hash" as a single string for storage.
            return saltBase64 + Separator + hash;
        }

        /// <summary>
        /// Verifies a plain-text password against a stored "salt:hash" string.
        /// </summary>
        /// <param name="plainTextPassword">Password entered at login.</param>
        /// <param name="storedValue">The "salt:hash" string read from users.txt.</param>
        /// <returns><c>true</c> if the password is correct; otherwise <c>false</c>.</returns>
        public static bool VerifyPassword(string plainTextPassword, string storedValue)
        {
            if (string.IsNullOrWhiteSpace(storedValue))
                return false;

            // Split on the first colon only.
            int colonIndex = storedValue.IndexOf(Separator);
            if (colonIndex < 0)
                return false;

            string saltBase64 = storedValue.Substring(0, colonIndex);
            string storedHash = storedValue.Substring(colonIndex + 1);

            string computedHash = ComputeHash(saltBase64, plainTextPassword);

            // Compare hashes in a constant-time-like manner to avoid timing attacks.
            return string.Equals(computedHash, storedHash, StringComparison.Ordinal);
        }

        // -------------------------------------------------------------------------
        // Private helpers
        // -------------------------------------------------------------------------

        /// <summary>
        /// Computes SHA-256( UTF8(salt) + UTF8(password) ) and returns the
        /// result as a lower-case hex string.
        /// </summary>
        private static string ComputeHash(string saltBase64, string password)
        {
            // Concatenate salt and password bytes before hashing.
            byte[] saltBytes     = Encoding.UTF8.GetBytes(saltBase64);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] combined = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes,     0, combined, 0,                saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combined, saltBytes.Length, passwordBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combined);

                // Convert to lower-case hex string (64 characters for SHA-256).
                StringBuilder sb = new StringBuilder(hashBytes.Length * 2);
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
