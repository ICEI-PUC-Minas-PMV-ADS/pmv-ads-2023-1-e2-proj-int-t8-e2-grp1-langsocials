using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Cryptography;

public class CryptographyService : ICryptographyService
{
    const int keySize = 64;
    const int iterations = 350000;
    private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    public bool Compare(string rawText, byte[] cypherText, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(rawText, salt, iterations, hashAlgorithm, keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, cypherText);
    }

    public (byte[] Hash, byte[] Salt) GenerateHash(string rawText)
    {
        var salt = RandomNumberGenerator.GetBytes(keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(rawText),
            salt,
            iterations,
            hashAlgorithm,
            keySize);

        return (hash, salt);
    }
}
