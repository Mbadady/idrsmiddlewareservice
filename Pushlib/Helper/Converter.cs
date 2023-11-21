using System;
using DataProj.Domain;
using dmslib;
//using dmslib;
//using Pushlib.Domain;
using Pushlib.DTO;
using repocore;
using Util;
//using Util.Domain;
//using dmscoreapi;
//using repocore;

namespace Pushlib
{
    public class Converter
    {
        public Converter()
        {
            Banks = new List<BankData>();
        }

        public List<BankData> Banks { get; set; }
        dmscoreapi.Data.Lookups lups = new dmscoreapi.Data.Lookups();

        public string Maskpan(string pan)
        {
            pan = pan.Trim().Replace(" ", "");
            int panl = pan.Length;
            int lastdigs = panl > 12 ? panl - 12 : 0;
            return (pan.Substring(0, 6) + "******" + pan.Trim().Substring(12, lastdigs));

        }

        public object Convert(Transaction t)
        {
            //if(t.Termclass.ToUpper().Trim() == "ATM")
            //{

            //    var AtmRequestDTO = new ATMRequest()
            //    {
            //        AccountName = Util.Util.Nullstring(),
            //        //AccountNumber = Util.Util.Nullstring(),
            //        AcquirerBank = lups.GetCbncode(Banks, t.Acquirerfiid?.ToString(), t.Rawdatarecipient)?.ToString().PadLeft(3, '0'),
            //        IssuingBank = lups.GetCbncode(Banks, t.Issuerfiid?.ToString())?.ToString()?.PadLeft(3, '0'),
            //        AcquirerRRN = Util.Util.Nullstring(t.Acqrrn, "000000000000"),
            //        //Amount = Util.Util.Nullstring((t.Transactionamount * 100).ToString()),
            //        Amount = t.Transactionamount,
            //        ApprovalAuthorizationCode = Util.Util.Nullstring(t.Approvalcode, "000000"),
            //        ARN = t?.Acqreferenceno,
            //        //DateOfTransaction = Util.Util.ConcatDateTimeWithDash(t.Localtransactiondate.Value),
            //        //DateOfSettlement = Util.Util.ConcatDateTimeWithDash(t.Onlinesettlementdate.Value),
            //        DateOfTransaction = DateTime.Parse("2023-09-29T11:00:00.000Z"),
            //        DateOfSettlement = DateTime.Now.AddDays(-1),
            //        IssuerRRN = Util.Util.Nullstring(t.Extrrn),
            //        FullPAN = t.Cardnumber,
            //        STAN = t?.Acqstan,
            //        TransactionID = t.Transid,
            //        TerminalID = Util.Util.Nullstring(t.Terminalid),
            //        TransactionChannelID = Util.Util.Nullstring(t.Termclass.ToUpper().Trim() == "ATM" ? "ATM" : "POS"),
            //        AccountNumber = Util.Util.Nullstring(t.Customeracct),
            //        AtmLocation = Util.Util.Nullstring(t.AtmLocation),
            //        //AtmLocation = "Kaduna Main Branch",
            //        TransactionTypeCode = Util.Constants.EnumToStringTransactionTypeCode(TransactionTypeCode.Normal)

            //    };


            //    return AtmRequestDTO;
            //}
            //else
            //{
            //    var PosWebRequestDTO = new PosWebRequest()
            //    {
            //        AccountName = Util.Util.Nullstring(),
            //        AccountNumber = Util.Util.Nullstring(),
            //        AcquirerBank = lups.GetCbncode(Banks, t.Acquirerfiid?.ToString(), t.Rawdatarecipient)?.ToString().PadLeft(3, '0'),
            //        IssuingBank = lups.GetCbncode(Banks, t.Issuerfiid?.ToString())?.ToString()?.PadLeft(3, '0'),
            //        AcquirerRRN = Util.Util.Nullstring(t.Acqrrn, "000000000000"),
            //        //Amount = Util.Util.Nullstring((t.Transactionamount * 100).ToString()),
            //        Amount = t.Transactionamount,
            //        ApprovalAuthorizationCode = Util.Util.Nullstring(t.Approvalcode, "000000"),
            //        ARN = t?.Acqreferenceno,
            //        DateOfTransaction = DateTime.Parse("2023-09-29T11:00:00.000Z"),
            //        DateOfSettlement = DateTime.Now,
            //        IssuerRRN = Util.Util.Nullstring(t.Extrrn),
            //        FullPAN = t.Cardnumber,
            //        STAN = t?.Acqstan,
            //        TransactionID = t.Transid,
            //        TerminalID = Util.Util.Nullstring(t.Terminalid),
            //        TransactionChannelID = Util.Util.Nullstring(t.Termclass.ToUpper().Trim() == "ATM" ? "ATM" : "POS"),
            //        MerchantName = Util.Util.Nullstring(t.Merchantname),
            //        MerchantID = Util.Util.Nullstring(t.Merchantid)

            //};
            //    //PushRequestDTO pushRequestDTO = new PushRequestDTO
            //    //{
            //    //    RequestID = t.Transid,
            //    //    Transactions = new List<object> { PosWebRequestDTO }
            //    //};

            //    return PosWebRequestDTO;

            //}

            var nbtran = new DataRequestDTO()
            {
                AccountName = Util.Util.Nullstring(),
                AccountNumber = Util.Util.Nullstring(),
                AcquirerBank = lups.GetCbncode(Banks, t.Acquirerfiid?.ToString(), t.Rawdatarecipient)?.ToString().PadLeft(3, '0'),
                IssuingBank = lups.GetCbncode(Banks, t.Issuerfiid?.ToString())?.ToString()?.PadLeft(3, '0'),
                AcquirerRRN = Util.Util.Nullstring(t.Acqrrn, "000000000000"),
                //Amount = Util.Util.Nullstring((t.Transactionamount * 100).ToString()),
                //Amount = t.Transactionamount,
                ApprovalAuthorizationCode = Util.Util.Nullstring(t.Approvalcode, "000000"),
                ARN = t?.Acqreferenceno,
                DateOfTransaction = DateTime.Parse("2023-09-29T11:00:00.000Z"),
                DateOfSettlement = DateTime.Now.AddDays(-1),
                IssuerRRN = Util.Util.Nullstring(t.Extrrn),
                FullPAN = t.Cardnumber,
                STAN = t?.Acqstan,
                TransactionID = t.Transid,
                TerminalID = Util.Util.Nullstring(t.Terminalid),
                TransactionChannelID = Util.Util.Nullstring(t.Termclass.ToUpper().Trim() == "ATM" ? "ATM" : "POS"),
                TransactionTypeCode = Constants.EnumToStringTransactionTypeCode(TransactionTypeCode.Normal)
            };

            if (t.Termclass.ToUpper().Trim() == "ATM")
            {
                ATMRequest a = new ATMRequest(nbtran);
                a.AccountNumber = Util.Util.Nullstring(t.Customeracct); //"0000000000",// 
                a.AtmLocation = Util.Util.Nullstring(t.AtmLocation);
                return a;
            }
            else
            {
                PosWebRequest p = new PosWebRequest(nbtran);
                p.MerchantName = Util.Util.Nullstring(t.Merchantname);
                p.MerchantID = Util.Util.Nullstring(t.Merchantid);
                return p;
            }

        }

        public List<object> ConvertBatch(List<Transaction> ts)
        {
            Banks = new dmscoreapi.Data.Lookups().LoadBanksData();
            List<object> nts = new List<object>();
            ts.ForEach(e => { nts.Add(Convert(e)); });
            return nts;
        }
    }
}

