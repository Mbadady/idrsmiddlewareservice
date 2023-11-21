using System;
using Newtonsoft.Json;

namespace SettlementNotificationLib.DTO
{
	public class DataResponseData
	{

        [JsonProperty("acquirerRRN")]
        public string AcquirerRRN { get; set; }

        [JsonProperty("STAN")]
        public string STAN { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("dateOfTransaction")]
        public DateTime DateOfTransaction { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("processorIDTransactionID")]
        public string ProcessorIDTransactionID { get; set; }

        [JsonProperty("ARN")]
        public string ARN { get; set; }

        [JsonProperty("disputeTicketId")]
        public string DisputeTicketId { get; set; }

        [JsonProperty("disputeType")]
        public string DisputeType { get; set; }

        [JsonProperty("transactionAmount")]
        public double TransactionAmount { get; set; }
    }
}

