using System;
using Newtonsoft.Json;

namespace SettlementStatusLib.DTO
{
	public class SettlementStatusRequestDTO
	{

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("data")]
        public List<DataRequestDTO> Data { get; set; }
    }
}

