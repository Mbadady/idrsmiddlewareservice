using System;
using Newtonsoft.Json;

namespace BankListLib.DTO
{
	public class BankResponseDTO
	{
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("data")]
        public List<DataResponseDTO> Data { get; set; }
    }
}

