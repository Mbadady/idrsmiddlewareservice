using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Util
{
    public class Util
    {
        public static DateTime GetDateFromString(string d)
        {
            var spl = d.Split('-');
            return d.Count() >= 3 ? new DateTime(int.TryParse(spl[2], out int year) ? year : 2000, Getmonthno(spl[1]), int.TryParse(spl[0], out int day) ? day : 0) : new DateTime();
        }

        public static int Getmonthno(string mnt)
        {
            for (int i = 1; i <= 12; i++)
                if (mnt.ToLower().Trim() == ((Month)(i - 1)).ToString().ToLower().Trim())
                    return i;
            return 0;
        }

        public static string ConcatDateforSingleMessage(DateTime idate, bool withdash = false)
        {
            if (idate == null) return "";
            string date;

            date = (idate.Month < 10 ? "0" + idate.Month.ToString() : idate.Month.ToString()) + (withdash ? "-" : "");
            date += (idate.Day < 10 ? "0" + idate.Day.ToString() : idate.Day.ToString()) + (withdash ? "-" : "");
            date += idate.Year.ToString().Substring(2, 2);
            return date;
        }

        public static string ConcatDate(DateTime idate, bool withdash = false)
        {
            if (idate == null) return "";
            string date;

            date = idate.Year.ToString() + (withdash ? "-" : "");
            date += (idate.Month < 10 ? "0" + idate.Month.ToString() : idate.Month.ToString()) + (withdash ? "-" : "");
            date += (idate.Day < 10 ? "0" + idate.Day.ToString() : idate.Day.ToString());
            return date;
        }

        public static List<List<T>> Batchids<T>(List<T> ids, int size)
        {
            List<List<T>> ranges = new List<List<T>>();
            for (int i = 0; i < ids.Count(); i += size)
            {
                ranges.Add(ids.GetRange(i, Math.Min(size, ids.Count() - i)));
            }
            return ranges;
        }

        public static KeyValuePair<DateTime, StringBuilder> StartCheck(string procname)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==========================================");
            var start = DateTime.Now;
            sb.AppendLine(procname);
            sb.AppendLine("Start time:  " + start);
            return new KeyValuePair<DateTime, StringBuilder>(start, sb);
        }
        public static StringBuilder EndCheck(DateTime start, StringBuilder sb)
        {
            var end = DateTime.Now;
            sb.AppendLine("End time:  " + end);
            sb.AppendLine("Span:  " + (end - start));
            sb.AppendLine("==========================================");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            return sb;
        }


        public static string ConcatSqlstring(string tablename, Dictionary<string, string> setprms, string colname, List<string> ids)
        {
            string q = "UPDATE " + tablename + " SET ";
            bool sfirst = true;
            int p = 0;
            foreach (var sp in setprms)
            {
                q += (sfirst ? "" : " ,") + sp.Key + " = '" + sp.Value + "'";
                sfirst = false;
            }

            q += " WHERE ";
            q += " " + colname + " in (" + Util.Stringify(ids, true) + ")";
            return q;
        }

        public static string Stringify<T>(List<T> ids, bool adquote = false)
        {
            bool first = true;
            string res = "";
            string quote = adquote ? "'" : "";
            foreach (var id in ids)
            {
                if (!first)
                    res += ",";
                else
                    first = false;
                res += quote + id.ToString() + quote;
            }
            return res;
        }

        public static string Nullstring(string val = "", string deflt = "")
        {
            return string.IsNullOrEmpty(val) ? string.IsNullOrEmpty(deflt) ? "" : deflt : val;
        }

        public static List<List<T>> Batch<T>(List<T> ids, int size)
        {
            List<List<T>> ranges = new List<List<T>>();

            for(int i = 0; i < ids.Count(); i += size)
            {
                ranges.Add(ids.GetRange(i, Math.Min(size, ids.Count() - i)));
            }

            return ranges;
        }

        //public static void Archivefile(string subpath)
        //{
        //    var dir = Constants.path + subpath;
        //    var fileList = System.IO.Directory.GetFiles(dir).Select(f => Path.GetFileName(f));
        //    foreach (string file in fileList)
        //    {
        //        string fileToMove = dir + file;
        //        string moveTo = Constants.archivepath + subpath + file;
        //        //moving file
        //        File.Move(fileToMove, moveTo);
        //    }

        //}

    }
}
