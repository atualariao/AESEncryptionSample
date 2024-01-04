
using Encryptor.Services;
using Entity;

namespace Encryptor
{
    public class Encryption
    {
        static void Main()
        {
            // Model
            AESEntity aesEntity = new();

            Console.Write("COPY YOUR ENCRYPTED TEXT, KEY, and IV\nEnter plaintext: ");
            string? plaintext = Console.ReadLine();

            // Original JSON message to be encrypted
            aesEntity.PlainText = plaintext;
            Console.WriteLine("Original Text: " + aesEntity.PlainText);

            // Generate Key
            aesEntity.AESKey = EncryptionService.GenerateKey();
            Console.WriteLine("Generated Key: " + aesEntity.AESKey);

            // Encrypt
            string ivKey = string.Empty;
            aesEntity.CipherText = EncryptionService.Encrypt(aesEntity.PlainText, aesEntity.AESKey, out ivKey);
            aesEntity.AESIVKey = ivKey;
            Console.WriteLine("Generated IV: " + aesEntity.AESIVKey);
            Console.WriteLine("Encrypted Text: " + aesEntity.CipherText);
        }
    }
}