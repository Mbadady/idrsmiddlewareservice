using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace industrydmspush
{

    public static class Encryption
    {

        private static SecureRandom SECURE_RANDOM = new SecureRandom();

        // Pre-configured Encryption Parameters

        public static int MacBitSize = 128;
        public static int NonceBitSize = 128;
        public static int KeyBitSize = 256;

        /*
         OrganizationCode: 002
        ApiKey: c2c7b3032f041ca3d3e9a101249d6940f49e1cf781aa60f6d5f4a3b89cfe3722
            IVKey: 91078310a35c89c9199b8242eeccb0b3
            Password: 1CQBTAQmh7TMtT8U
          */
        //static void Main(string[] args)
        //{
        //    string enc = encrypt("plainText", "c2c7b3032f041ca3d3e9a101249d6940f49e1cf781aa60f6d5f4a3b89cfe3722", "91078310a35c89c9199b8242eeccb0b3");
        //    string dc = decrypt(enc, "c2c7b3032f041ca3d3e9a101249d6940f49e1cf781aa60f6d5f4a3b89cfe3722", "91078310a35c89c9199b8242eeccb0b3");
        //    Console.WriteLine(dc);
        //}

        public static byte[] hexToByte(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static string bytesToHex(this IEnumerable<byte> hexBytes)
        {
            if (hexBytes == null) return null;
            if (hexBytes.Count() == 0) return string.Empty;

            var s = new StringBuilder();
            foreach (var b in hexBytes)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }


        public static string encrypt(string plainText, string key, string iv)
        {
            return encrypt(plainText, hexToByte(key), hexToByte(iv));
        }

        public static string decrypt(string encryptedText, string key, string iv)
        {
            return decrypt(encryptedText, hexToByte(key), hexToByte(iv));
        }

        public static string encrypt(string plainText, byte[] key, byte[] iv)
        {
            string sR = "";
            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);
                cipher.Init(true, parameters);
                byte[] encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
                int retLen = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sR = System.Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }
            return sR;
        }

        public static string encrypt(byte[] plainBytes, byte[] key, byte[] iv)
        {
            string sR = "";
            try
            {
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);
                cipher.Init(true, parameters);
                byte[] encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
                int retLen = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sR = System.Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }
            return sR;
        }

        public static byte[] encryptByte(byte[] plainBytes, byte[] key, byte[] iv)
        {
            byte[] sR = new byte[0];
            try
            {
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);
                cipher.Init(true, parameters);
                byte[] encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
                int retLen = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sR = encryptedBytes;
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }

            return sR;
        }

        public static string decrypt(string EncryptedText, byte[] key, byte[] iv)
        {
            string sR = "";
            try
            {
                byte[] encryptedBytes = System.Convert.FromBase64String(EncryptedText);

                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);
                cipher.Init(false, parameters);
                byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                int retLen = cipher.ProcessBytes
                        (encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);
                sR = Encoding.UTF8.GetString(plainBytes);
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }
            return sR;
        }


        public static string decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            string sR = "";
            try
            {
                //byte[] encryptedBytes = System.Convert.FromBase64String(EncryptedByte);

                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);
                cipher.Init(false, parameters);
                byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                int retLen = cipher.ProcessBytes
                        (encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);
                sR = Encoding.UTF8.GetString(plainBytes);
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }

            return sR;
        }


        public static byte[] decryptByte(byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            byte[] sR = new byte[0];
            try
            {
                // byte[] encryptedBytes = Base64.getDecoder().decode(EncryptedByte);
                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters =
                        new AeadParameters(new KeyParameter(key), MacBitSize, iv, null);

                cipher.Init(false, parameters);
                byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                int retLen = cipher.ProcessBytes
                        (encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                cipher.DoFinal(plainBytes, retLen);
                sR = plainBytes;
            }
            catch (Exception e)
            {//(UnsupportedEncodingException | IllegalArgumentException |
                //  IllegalStateException | DataLengthException | InvalidCipherTextException ex) {
                //log.error("ERROR: Unable to encrypt request >> ", ex.getMessage());
            }

            return sR;
        }

    }
}


