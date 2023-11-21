using System;
using Newtonsoft.Json;

namespace BankListLib.DTO
{
	public class DataResponseDTO
	{

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

