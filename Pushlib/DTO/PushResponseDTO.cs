using System;
using Newtonsoft.Json;
using Util;

namespace Pushlib.DTO
{
	public class PushResponseDTO
	{
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("responseCode")]
        public ResponseCode ResponseCode { get; set; }

        [JsonProperty("requestID")]
        public string RequestID { get; set; }

        
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("socket")]
        public bool Socket { get; set; }
    }
}

