using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Tools
{
    public static class Encryption
    {
        private static string key = "BQgDMul5ajZx3Ck41xv5a7Msz3z3kAQsgaeQe677wWI=";
        private static string Iv = "lwL7BKuyRd6gg2YC/s5Gl3BUZ9Xn6m2zExYWtt6qjiA=";
        private static int keyLength = 128;

        public static String AES_encrypt(String input)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = keyLength;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = mkey(key, keyLength);
            aes.IV = mkey(Iv, 128);

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(input);
                    cs.Write(xXml, 0, xXml.Length);
                    cs.FlushFinalBlock();
                }

                xBuff = ms.ToArray();
            }

            return Convert.ToBase64String(xBuff, Base64FormattingOptions.None);
        }

        public static String AES_decrypt(String Input)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = keyLength;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = mkey(key, keyLength);
                aes.IV = mkey(Iv, 128);

                var decrypt = aes.CreateDecryptor();
                byte[] encryptedStr = Convert.FromBase64String(Input);

                string Plain_Text;

                using (var ms = new MemoryStream(encryptedStr))
                {
                    using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            Plain_Text = reader.ReadToEnd();
                        }
                    }
                }

                return Plain_Text;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private static byte[] mkey(string skey, int keyLength)
        {
            int length = keyLength / 8;
            byte[] key = Encoding.UTF8.GetBytes(skey);
            byte[] k = new byte[length];

            for (int i = 0; i < key.Length; i++)
            {
                //k[i % 16] = (byte)(k[i % 16] ^ key[i]);
                k[i] = key[i];
                if (i == length - 1)
                    break;
            }

            return k;
        }
    }
}

