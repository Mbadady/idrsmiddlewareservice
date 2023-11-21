using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Util;

namespace Pushlib.DTO
{
    public class DataRequestDTO
    {
        public DataRequestDTO()
        {
            ProcessorID = "UPSL";
        }

        [JsonProperty("accountName")]
        public string? AccountName { get; set; }

        [JsonProperty("accountNumber")]
        public string?  AccountNumber{ get; set; }

        [Required]
        [JsonProperty("acquirerBank")]
        public string AcquirerBank { get; set; }

        [Required]
        [JsonProperty("issuingBank")]       
        public string IssuingBank { get; set; }


        [Required]      
        [JsonProperty("acquirerRRN")]
        public string AcquirerRRN { get; set; }

        [Required]
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("approvalAuthorizationCode")]
        public string? ApprovalAuthorizationCode  { get; set; }

            
        public string? ARN { get; set; }

        [Required]
        [JsonProperty("dateOfTransaction")]
        public DateTime DateOfTransaction { get; set; }

        [Required]
        [JsonProperty("dateOfSettlement")]
        public DateTime DateOfSettlement { get; set; }

        [Required]
        [JsonProperty("issuerRRN")]
        public string IssuerRRN { get; set; }

        [Required]
        [JsonProperty("processorIDTransactionID")]
        public string ProcessorIDTransactionID { get { return ProcessorID + "-" + TransactionID; } }

        [JsonProperty("transactionID")]
        public string TransactionID { get; set; }

        [Required]
        [JsonProperty("fullPAN")]
        public string FullPAN { get; set; }

        [Required]
        public string STAN { get; set; }


        [JsonProperty("terminalID")]
        public string? TerminalID { get; set; }

        [Required]
        [JsonProperty("transactionChannelID")]
        public string TransactionChannelID { get; set; }


        [Required]
        [JsonProperty("processorID")]
        public string ProcessorID { get; set; }

        [JsonProperty("otherDetails")]
        public JObject OtherDetails{ get; set; }

        [Required]
        [JsonProperty("transactionTypeCode")]
        public string TransactionTypeCode { get; set; }

    }
}