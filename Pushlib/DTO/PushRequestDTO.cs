using System;
using Lib;
using Newtonsoft.Json;
using Util;

namespace Pushlib.DTO
{
    public class PushRequestDTO
    {
        [JsonProperty("data")]
        public List<object> Transactions { get; set; }

        [JsonProperty("requestID")]
        public string? RequestID
        {
            get { return GenerateRandomRequestID(); }
            set {}
        }

        // Method to generate a random 12-digit requestID 
        private string GenerateRandomRequestID()
        {
            Random random = new Random();
            long randomNumber = (long)(random.NextDouble() * 1000000000000); // Generate a random long
            return randomNumber.ToString("000000000000");
        }
    }

}