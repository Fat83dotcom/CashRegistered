using Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Repository.Security;

public class Argon2Services : IPasswordHasher
{
    private const int DegreeOfParallelism = 8;
    private const int MemorySize = 128 * 1024;
    private const int Iterations = 4;
    private const int SaltSize = 16;

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            MemorySize = MemorySize,
            Iterations = Iterations
        };

        var hash = argon2.GetBytes(32);

        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public bool VerifyHash(string password, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(hashedPassword)) 
            return false;

        var parts = hashedPassword.Split('.');
        
        if (parts.Length != 2) 
            return false;

        try
        {
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[1]);

            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                MemorySize = MemorySize,
                Iterations = Iterations
            };

            var newHash = argon2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hash, newHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}