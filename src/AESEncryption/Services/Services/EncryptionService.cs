﻿using System.Security.Cryptography;

namespace Encryptor.Services
{
    public class EncryptionService
    {
        // Code to generate the AES key
        public static string GenerateKey()
        {
            string keyBase64 = string.Empty;

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();

                keyBase64 = Convert.ToBase64String(aes.Key);
            }

            return keyBase64;
        }

        public static string Encrypt(string plainText, string key, out string ivKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Convert.FromBase64String(key);
                aes.GenerateIV();

                ivKey = Convert.ToBase64String(aes.IV);

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] encryptedData;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encryptedData = ms.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedData);
            }
        }
    }
}
