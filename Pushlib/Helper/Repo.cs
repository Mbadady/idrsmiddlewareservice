using DataProj.DataContext;
using DataProj.Domain;
using dmslib;
using Pushlib;
//using Pushlib.Data;
//using Pushlib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repocore
{
    public class Repo
    {

        public int GetCountForDay(DateTime transdate)
        {
            var enddate = transdate.AddDays(1);
            int count = 0;
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {


                    count = ctx.Transactions.Where(t => t.Localtransactiondate >= transdate && t.Localtransactiondate < enddate && t.Transactionamount > 0 && t.Transactionamount > 0 && !string.IsNullOrEmpty(t.Extrrn)).Select(t => t.Transid).Count();
                }
            }
            catch (Exception e)
            {

            }
            return count;
        }

        public List<object> GetTransactions(DateTime transdate, int batch = 1)
        {
            var trans = new List<Transaction>();

            string rngname = "Range" + transdate.Year.ToString() + "-" + transdate.Month.ToString() + "-" + transdate.Day.ToString();
            List<List<string>> ranges = new List<List<string>>();
            ranges = null;
           // AppCache cache = new AppCache();
           // ranges = (List<List<string>>)cache[rngname];
            if (ranges == null)
            {
                var enddate = transdate.AddDays(1);
                try
                {
                    using (ApplicationDbContext ctx = new ApplicationDbContext())
                    {
                        //ctx.Database.CommandTimeout = 420;
                        var transid = ctx.Transactions.Where(t => t.Localtransactiondate >= transdate && t.Localtransactiondate < enddate && t.Transactionamount > 0 && t.Transactionamount > 0 && !string.IsNullOrEmpty(t.Extrrn)/*&& !string.IsNullOrEmpty(t.customeracct)*/ ) /*.Take(2000)*/.Select(t => t.Transid).ToList();
                        ranges = Splitids(transid);
                    }
                }
                catch (Exception e)
                {

                }

                //cache.Insert(rngname, ranges, new List<string>() { Util.Constants.banksdatapath });
            }

            if (ranges.Count >= batch)
            {
                var rng = ranges[batch - 1];
                var rnges = Util.Util.Batch(rng, 1000);
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    foreach (var rrng in rnges)
                        trans.AddRange(ctx.Transactions.Where(t => rrng.Contains(t.Transid)).ToList());
                }
            }
            return new Converter().ConvertBatch(trans);
        }

        public List<List<string>> Splitids(List<string> ids)
        {
            List<List<string>> ranges = new List<List<string>>();
            for (int i = 0; i < ids.Count(); i += Util.Constants.batchsize)
            {
                ranges.Add(ids.GetRange(i, Math.Min(Util.Constants.batchsize, ids.Count() - i)));
            }
            return ranges;
        }
    }
}
