using Application.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Application.Services
{
    public class PasswordService : IPasswordService
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;

        public string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: KeySize);

            byte[] combinedBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, combinedBytes, 0, SaltSize);
            Array.Copy(hash, 0, combinedBytes, SaltSize, KeySize);

            return Convert.ToBase64String(combinedBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] combinedBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[SaltSize];
            byte[] storedHash = new byte[KeySize];

            Array.Copy(combinedBytes, 0, salt, 0, SaltSize);
            Array.Copy(combinedBytes, SaltSize, storedHash, 0, KeySize);

            byte[] computedHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: KeySize);

            return storedHash.SequenceEqual(computedHash);
        }
    }
}
