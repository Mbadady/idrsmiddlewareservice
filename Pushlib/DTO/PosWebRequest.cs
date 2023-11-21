using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Util;

namespace Pushlib.DTO
{
	public class PosWebRequest : DataRequestDTO
	{

        public PosWebRequest()
        {
            TransactionChannelID = Constants.EnumToStringTransactionChannelID(Util.TransactionChannelID.POS) == "POS" ? "POS": "WEB";
        }

        public PosWebRequest(DataRequestDTO t)
        {
            TransactionChannelID = "POS";
            AccountName = t.AccountName;
            AccountNumber = t.AccountNumber;
            AcquirerBank = t.AcquirerBank;
            IssuingBank = t.IssuingBank;
            AcquirerRRN = t.AcquirerRRN;
            Amount = t.Amount;
            ApprovalAuthorizationCode = t.ApprovalAuthorizationCode;
            ARN = t.ARN;
            DateOfTransaction = t.DateOfTransaction;
            DateOfSettlement = t.DateOfSettlement;
            IssuerRRN = t.IssuerRRN;
            TransactionID = t.TransactionID;
            FullPAN = t.FullPAN;
            STAN = t.STAN;
            TerminalID = t.TerminalID;
            TransactionChannelID = t.TransactionChannelID;
        }
        [Required]
        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }


        [Required]
        [JsonProperty("merchantID")]
        public string? MerchantID { get; set; }
    }
}

