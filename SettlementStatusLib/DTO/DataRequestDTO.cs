using System;
using Newtonsoft.Json;

namespace SettlementStatusLib.DTO
{
	public class DataRequestDTO
	{
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("disputeTicketID")]
        public string DisputeTicketID { get; set; }

        [JsonProperty("disputeSettlementDate")]
        public DateTime DisputeSettlementDate { get; set; }
    }
}

