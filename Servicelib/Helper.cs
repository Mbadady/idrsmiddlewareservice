using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Util;
using System.Timers;

namespace Servicelib
{
    public class Helper
    {

        private static int eventId = 1;
        private static int standardinterval = 15000; //600000;// 10 minutes
        public static Func<List<AppInvoker>, string> _invk;

        public static string RunInstance(Func<List<AppInvoker>, string> invk)
        {
            _invk = invk;
            Task.Run(() => StartTimer());
            string exr = "quit"; // local variable
            try
            {
                string q;
                do

                {
                    //Console.Clear();
                    q = Console.ReadLine().ToString();
                    if (q.ToUpper() == "Q")
                    {
                        Console.WriteLine("\n\nAre you sure you want to quit? Y/N");
                        q = Console.ReadKey().Key.ToString();
                        Console.ReadLine();
                    }
                    else
                    {
                        //var spl = q.Split(" ");
                        //var prd = DateTime.Now.AddDays(-1);
                        //var rundate = spl.Count() > 1 ? Util.Util.GetDateFromString(spl[1]) : new DateTime(prd.Year, prd.Month, prd.Day, 0, 0, 0);
                        //Console.WriteLine(rundate);
                        //if (q == "1")
                        //{
                        //}
                        //else
                        //if (q.StartsWith("2"))
                        //{
                        //    //
                        //}
                        ; //others
                        q = "";
                        Console.WriteLine("");
                    }
                }
                while (q.ToUpper() != "Y");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("");
                Console.WriteLine(e.StackTrace);
                exr = "error";
            }
            Console.WriteLine(exr);
            Console.ReadLine();
            return exr;
        }

        public static void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = standardinterval;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        public static void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Console.WriteLine("running " + eventId++);
            var migrations = LoadInvokeMigrations();
            //_invk.Invoke(migrations);

            _invk.Invoke(migrations);


        }
        public static List<AppInvoker> LoadInvokeMigrations()
        {
            List<AppInvoker> tobeinvoked = new List<AppInvoker>();
            if (!File.Exists(Util.Constants.invokerxmlpath))
            {
                return tobeinvoked;
            }

            DateTime nowdate = DateTime.Now;
            try
            {
                var xdoc = XElement.Load(Util.Constants.invokerxmlpath);
                var tasks = from c in xdoc.Elements("tasks") select c;
                var rootpath = xdoc.Element("rootpath").Value;

                foreach (var task in tasks?.Elements("task"))
                {
                    string name = task?.Element("name")?.Value;
                    string hr = task?.Element("hour")?.Value;
                    string mn = task?.Element("minute")?.Value;
                    string intv = task?.Element("interval")?.Value;
                    int hour = nowdate.Hour;
                    int day = nowdate.Day;

                    int min = int.TryParse(mn, out int mmin) ? mmin : 0;

                    if (!string.IsNullOrEmpty(intv))
                    {
                        if (intv.Trim().ToLower() == "daily" || intv.Trim().ToLower() == "monthly")
                        {
                            if (!int.TryParse(hr, out int hur))
                            {
                                continue;
                            }
                            hour = hur;

                            if (intv.Trim().ToLower() == "monthly")
                            {
                                day = 1;
                                hour = 7;
                            }
                        }
                    }

                    if (intv.Trim().ToLower() == "minutely")
                    {
                        var m = 0;
                        while (m <= (nowdate.Minute - min))
                        {
                            m += min;
                            //Console.WriteLine(m);
                        }
                        min = m;
                    }

                    DateTime invokeTime = new DateTime(nowdate.Year, nowdate.Month, day, hour, min, 0);
                    if (nowdate >= invokeTime && nowdate.Subtract(invokeTime) < new TimeSpan(0, 0, 0, 0, standardinterval))
                    {
                        string useroot = task?.Element("userootpath")?.Value;
                        string urlpath = task?.Element("path")?.Value;
                        string fcol = task?.Element("owner")?.Value;
                        string tclass = task?.Element("ownertype")?.Value;
                        tobeinvoked.Add(new AppInvoker() { Name = name, Time = invokeTime, Path = (!string.IsNullOrEmpty(useroot) && useroot.ToLower().Trim() == "true") ? rootpath + urlpath : urlpath, Interval = intv, Owner = fcol, Ownertype = tclass });

                    }
                }
            }
            catch (Exception e)
            {
            }
            foreach(var invk in tobeinvoked)
            {
                Console.WriteLine(invk.Name);
                Console.WriteLine(invk.Interval);
            }
            return tobeinvoked;
        }
    }


    public class AppInvoker
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Interval { get; set; }
        public string Path { get; set; }
        public string UrlPath { get { return Path + "/" + Interval + "/" + Owner + "/" + Ownertype; } }
        public string Owner { get; set; }
        public string Ownertype { get; set; }
    }

}
