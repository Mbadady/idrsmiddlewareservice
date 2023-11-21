using dmslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace dmscoreapi.Data
{
    public class Lookups
    {
        public List<BankData> LoadBanksData()
        {
            Loaddocs l = new Loaddocs();
            var res = l.LoadBanks(l.LoadXls(Util.Constants.banksdatapath)).OrderBy(b => b.BANKNAME).ToList();
            return res;
        }

        public string GetCbncode(string fiid, string rawdatarecipient = null)
        {
            var res = LoadBanksData().FirstOrDefault(l => (!string.IsNullOrEmpty(rawdatarecipient) && l.RAWDATARECIEPIENT?.Trim()?.ToUpper() == rawdatarecipient) || l.BANKFIID?.Trim()?.ToUpper() == fiid)?.CBNCODE;
            return res;
        }

        public string GetCbncode(List<BankData> bankdate, string fiid, string rawdatarecipient = null)
        {
            var res = bankdate.FirstOrDefault(l => l.RAWDATARECIEPIENT?.Trim()?.ToUpper() == rawdatarecipient || l.BANKFIID?.Trim()?.ToUpper() == fiid)?.CBNCODE;
            return res;
        }
    }
}
