using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Util
{
    public enum Month
    { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }

    public enum ResponseCode
    {
        [Display(Name ="Success")]
        Success = 00,

        [Display(Name ="Invalid Parameter")]
        InvalidParameter = 01,

        [Display(Name ="Request Failed")]
        RequestFailed = 89,

        [Display(Name ="Empty Data")]
        EmptyData = 99,

        [Display(Name = "Partial Success")]
        PartialSuccess = 88,
    }

    public enum Status
    {
        // 00 for pending
        Pending,

        // 01 for settled transaction
        Settled
    }

    public enum TransactionChannelID
    {
        POS,
        WEB,
        ATM
    }

    public enum ApiType
    {
        POST,
        GET,
        PUT,
        DELETE
    }


    public enum TransactionTypeCode
    {
       
        Normal,
        Reversed,
        Refunded,

    }



    public static class Constants
    {

        static IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json") // Adjust this to your configuration file location
            .Build();

        //public static string path = @"C:\Users\Smbah\Documents\TestForMigration 2\inetpub\Middlewaredata\data\xml\";
        public static string path = @"/Users/mac/Desktop/TestForMigration/inetpub/Middlewaredata/data/XML/";
        // public static string path = @"/home/saccount/Mcmiddleware/Middlewaredata/data/";
        //static IConfiguration configuration = new ConfigurationBuilder()
        //                               .AddJsonFile(path + "appsettings.json", true, true)
        //                               .Build();

        //public const string root = @"C:\Users\Smbah\Downloads\upidrsmiddleware\Util\"; //linux
        public const string root = @"/Users/mac/Downloads/upidrsmiddleware/Util/";
        //public const string root = @"/home/saccount/Mcmiddleware/Middlewaredata/data/"; //linux     
        public static string invokerxmlpath = path + "invoker_urls_unisetv2.xml";

        public static string password = configuration["ApiSettings:DefaultHeaders:Password"];
        public static string organizationCode = configuration["ApiSettings:DefaultHeaders:OrganizationCode"];
        public static string aeskey = configuration["ApiSettings:DefaultHeaders:AESKEY"];
        public static string ivspec = configuration["ApiSettings:DefaultHeaders:IVSPEC"];
        public static string baseAddress = configuration["ApiSettings:BaseAddress"];
        public static string connectionString = configuration["ConnectionStrings:PushLibConnectionString"];
        public const string banksdatapath = root + "Insitution table.xls";
        public const string transactiondatapath = root + "transactiondata.txt";
        //public const string banksdatapath = "Insitution table.xls";
        public const int batchsize = 10;

        //public static string OrganizationCode = "002";
        public static string CurrentDate = DateTime.Now.ToString("yyyyMMdd");
        //public static string Password = "q2OT7mG0UI2PrUba";

        private static SecureRandom SECURE_RANDOM = new SecureRandom();

        // Pre-configured Encryption Parameters

        public static int MacBitSize = 128;
        public static int NonceBitSize = 128;
        public static int KeyBitSize = 256;

        public static string Base64Enconding()
        {
            string concatenatedValue = organizationCode;

            // Convert the concatenated string to bytes
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(concatenatedValue);

            // Convert the byte array to Base64
            string base64String = Convert.ToBase64String(bytesToEncode);

            return base64String;
        }

        public static string SignatureSHA()
        {
            string concatenatedValue = organizationCode + CurrentDate + password;

            // Compute the SHA-256 hash of the concatenated string
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(concatenatedValue));

                // Convert the byte array to a hexadecimal string
                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }

                string sha256Hash = hashBuilder.ToString();

                return sha256Hash;
            }
        }

        public static string EnumToStringTransactionChannelID(TransactionChannelID value)
        {
            switch (value)
            {
                case TransactionChannelID.POS:
                    return "POS";
                case TransactionChannelID.ATM:
                    return "ATM";
                case TransactionChannelID.WEB:
                    return "WEB";
                default:
                    throw new ArgumentException("Unknown Value. Value must be ATM, POS OR WEB");
            }
        }

        public static string EnumToStringStatus(Status value)
        {
            switch (value)
            {
                case Status.Settled:
                    return "01";
                case Status.Pending:
                    return "00";
                default:
                    throw new ArgumentException("Unknown Value. Value must be ATM, POS OR WEB");
            }
        }

        public static string EnumToStringTransactionTypeCode(TransactionTypeCode value)
        {
            switch (value)
            {
                case TransactionTypeCode.Normal:
                    return "01";
                case TransactionTypeCode.Refunded:
                    return "03";
                case TransactionTypeCode.Reversed:
                    return "02";
                default:
                    throw new ArgumentException("Value must be Normal, Refunded or Reversed");
            }
        }
    }

}


