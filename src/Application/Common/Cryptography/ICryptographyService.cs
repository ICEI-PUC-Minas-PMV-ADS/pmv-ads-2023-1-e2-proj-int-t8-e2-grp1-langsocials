namespace Application.Common.Cryptography;
public interface ICryptographyService
{
    bool Compare(string rawText, byte[] cypherText, byte[] salt);
    (byte[] Hash, byte[] Salt) GenerateHash(string rawText);
}
