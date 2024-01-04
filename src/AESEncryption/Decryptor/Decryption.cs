
using Entity;
using Services.Services;

namespace Decryptor
{
    public class Decryption
    {
        static void Main()
        {
            // Model
            AESEntity aesEntity = new();

            // Enter key
            Console.Write("Enter Key: ");
            aesEntity.AESKey = Console.ReadLine();

            // Enter IV
            Console.Write("Enter IV: ");
            aesEntity.AESIVKey = Console.ReadLine();

            // Enter cipher text
            Console.Write("Enter cipher text: ");
            aesEntity.CipherText = Console.ReadLine();

            try
            {
                // Decrypt
                string plainText = string.Empty;
                aesEntity.CipherToPlainText = DecryptionService.Decrypt(aesEntity.CipherText, aesEntity.AESKey, aesEntity.AESIVKey);
                Console.Write("Decrypted Text: " + aesEntity.CipherToPlainText);

                Console.WriteLine($"\n\n AESKey: {aesEntity.AESKey} \n AESIVKey: {aesEntity.AESIVKey} \n PlainText: {aesEntity.PlainText} \n CipherToPlainText: {aesEntity.CipherToPlainText} \n");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write($"\n Error: " + ex.Message);

                Console.ReadLine();
            }
        }
    }
}