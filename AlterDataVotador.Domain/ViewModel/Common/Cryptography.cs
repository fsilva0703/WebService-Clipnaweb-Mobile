using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AlterDataVotador.Domain.ViewModel.Common
{
    public static class Cryptography
    {
        private static readonly Byte[] CryptographicKeyPassword = { 0xB4, 0xEB, 0xAD, 0x41, 0x12, 0xD8, 0x25, 0xF3, 0x1C, 0x9D, 0xA6, 0x83, 0x49, 0x8F, 0xD8, 0x9E };
        //private const String cryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
        //private static Byte[] IV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        private static UTF8Encoding enconding = new UTF8Encoding();
        private static Byte[] Key = enconding.GetBytes("ZmlhcyBjb20gUmluamRhZWwgLyBBRVM=");
        private static Byte[] IV = enconding.GetBytes("9532654BD7815470");

        public static String HashPassword(String paramSenha)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: paramSenha,
                    salt: CryptographicKeyPassword,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 12000,
                    numBytesRequested: 256 / 8
                )
            );
        }

        public static String EncryptString(String plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            Byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Aes AesAlg = Aes.Create())
            {
                AesAlg.Key = Key;
                AesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = AesAlg.CreateEncryptor(AesAlg.Key, AesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        public static String DecryptString(String EncryptedText)
        {
            Byte[] cipherText = Convert.FromBase64String(EncryptedText);


            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            String plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Aes AesAlg = Aes.Create())
            {
                AesAlg.Key = Key;
                AesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = AesAlg.CreateDecryptor(AesAlg.Key, AesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
