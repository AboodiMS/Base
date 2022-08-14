using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Helper101
{
    public static class EncryptionMD5
    {
        private readonly static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private readonly static int BlockSize = 128;

        public static string Encryption(this string text,string key)
        {
            try
            {
                if (key == "")
                    return "";
                byte[] bytes = Encoding.Unicode.GetBytes(text);
                //Encrypt
                SymmetricAlgorithm crypt = Aes.Create();
                HashAlgorithm hash = MD5.Create();
                crypt.BlockSize = BlockSize;
                crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key));
                crypt.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            catch
            {
                return "";
            }
        }

        public static string Decryption(this string text,string key)
        {
            try
            {
                int indexOf = text.IndexOf("\0");
                if (indexOf > 0)
                    text = text.Substring(0, indexOf);
                if (key == "")
                    return "";
                //Decrypt
                byte[] bytes = Convert.FromBase64String(text);
                SymmetricAlgorithm crypt = Aes.Create();
                HashAlgorithm hash = MD5.Create();
                crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key));
                crypt.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[bytes.Length];
                        cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);

                        string UnencryptedText = Encoding.Unicode.GetString(decryptedBytes);

                        indexOf = UnencryptedText.IndexOf("\0");
                        if (indexOf > 0)
                            UnencryptedText = UnencryptedText.Substring(0, indexOf);

                        return UnencryptedText;
                    }
                }
            }
            catch
            {
                return "";
            }
        }

    }
}
