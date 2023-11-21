using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Util;

namespace Pushlib.DTO

{
	public class ATMRequest : DataRequestDTO
    {
        

        public ATMRequest()
        {
            TransactionChannelID = "ATM";
        }

        public ATMRequest(DataRequestDTO t)
        {
            TransactionChannelID = "ATM";
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
            TransactionTypeCode = t.TransactionTypeCode;
        }


        [JsonProperty("atmLocation")]
        [Required]
        public string AtmLocation { get; set; }
    }
}

