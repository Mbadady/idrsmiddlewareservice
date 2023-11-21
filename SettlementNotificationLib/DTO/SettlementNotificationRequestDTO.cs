using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SettlementNotificationLib.DTO
{
	public class SettlementNotificationRequestDTO
	{
        [Required]
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [Required]
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("includeFetchedDisputes")]
        public int IncludeFetchedDisputes { get; set; }

        [JsonProperty("includeAllStatus")]
        public int IncludeAllStatus { get; set; }
    }
}

