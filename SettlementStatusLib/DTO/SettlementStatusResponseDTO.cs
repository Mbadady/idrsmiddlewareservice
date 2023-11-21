using System;
using Newtonsoft.Json;

namespace SettlementStatusLib.DTO
{
	public class SettlementStatusResponseDTO
	{

        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("data")]
        public DataRequestDTO Data { get; set; }
    }
}

