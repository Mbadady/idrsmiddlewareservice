using System;
using Lib.DTO;
using Newtonsoft.Json;

namespace SettlementNotificationLib.DTO
{
	public class SettlementNotificationResponseDTO
	{
        [JsonProperty("requestId")]
        public long RequestId { get; set; }

        [JsonProperty("totalRecord")]
        public int TotalRecord { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("data")]
        public List<DataResponseData> Data { get; set; }

        
    }
}

