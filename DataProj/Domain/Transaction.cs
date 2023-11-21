using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataProj.Domain;

public class Transaction
{
    //public string Transid { get; set; }
    public string Transid { get; set; } = null!;

    public DateTime? Onlinesettlementdate { get; set; }

    public string? Rawdatarecipient { get; set; }

    public DateTime? Vssprocessingdate { get; set; }

    public DateTime? Vnpsettdate { get; set; }

    public string? Terminalid { get; set; }

    public string? AtmAcquirer { get; set; }

    public string? AtmLocation { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardseq { get; set; }

    public double Transactionamount { get; set; }

    public string? TransactionamtCurrencycode { get; set; }

    public double? Settlementamount { get; set; }

    public string? SettlementamtCurrencycode { get; set; }

    public double? Reimbursementfee { get; set; }

    public DateTime? Localtransactiondate { get; set; }

    public string? Localtransactiontime { get; set; }

    public string? Tracenumber { get; set; }

    public string? Batchnumber { get; set; }

    public string? Responsedesc { get; set; }

    public string? Responsecode { get; set; }

    public string? Transactiontype { get; set; }

    public string? Requestmessagetype { get; set; }

    public string? Processingcode { get; set; }

    public string? Settlementmentserviceselected { get; set; }

    public double? Calculatedfeetovnp { get; set; }

    public double? Calculatedfeetobank { get; set; }

    public string? Sign { get; set; }

    public string? Approvalcode { get; set; }

    public string? Acqrrn { get; set; }

    public string? Revrequestid { get; set; }

    public DateTime? Transmissiondate { get; set; }

    public string? Transmissiontime { get; set; }

    public string? Feprrn { get; set; }

    public string? Extrrn { get; set; }

    public string? Acqstan { get; set; }

    public string? Origtype { get; set; }

    public double? Transactionfee { get; set; }

    public string? Issuerfiid { get; set; }

    public double? Acquirerfiid { get; set; }

    public string? Domestic { get; set; }

    public string? Host { get; set; }

    public double? Origtypeold { get; set; }

    public double? Transactionfeeold { get; set; }

    public double? Batchid { get; set; }

    public string? Customeracct { get; set; }

    public string? Termclass { get; set; }

    public string? Extstan { get; set; }

    public double? Acquirerfee { get; set; }

    public string? Phase { get; set; }

    public string? Merchantname { get; set; }

    public string? Phoneno { get; set; }

    public string? Invoicenum { get; set; }

    public string? Acqreferenceno { get; set; }

    public string? Maskedpan { get; set; }

    public string? Userdata { get; set; }

    public TimeOnly? Transimportdate { get; set; }

    public string? Merchantid { get; set; }

    public string? Textmess { get; set; }

    public double? Creditval { get; set; }

    public double? Originalamount { get; set; }

    public string? Tranclass { get; set; }

    public string? Toacct2 { get; set; }
}

