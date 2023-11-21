using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DataProj.Domain
{
    public class Claim
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Idrsid { get; set; }

        public string? Stan { get; set; }

        public double? Amount { get; set; }

        public double? Transactionamount { get; set; }

        public DateTime? Dateoftransaction { get; set; }

        public string? Status { get; set; }

        public string? Acqrrn { get; set; }

        public string? Arn { get; set; }

        public string? Typecode { get; set; }

        public string? Disputeticketid { get; set; }

        public string? Errorreason { get; set; }

        public string? Requestid { get; set; }

        public string Processoridtransactionid { get; set; }

        public string Disputetype { get; set; }
    }
}

