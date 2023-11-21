using DataProj.DataContext;
using industrydmspush;
using Lib.DTO;
using Microsoft.Extensions.Configuration;
using Pushlib;
//using Pushlib.Model;
using Servicelib;
using SettlementNotificationLib;
using SettlementStatusLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pushservice
{
    class Program
    {
        static void Main(string[] args)
        {
    
            //Invokeservice(new List<AppInvoker> { new AppInvoker { Name = "Pushservice" } });
            var mess = "Push service run start " + DateTime.Now.ToString();
            //  Lib.AppLogger.Log(mess, Util.Services.Claims.ToString());
            Helper.RunInstance(Invokeservice);

            Console.WriteLine(Util.Util.Getmonthno("1"));
        }

        static string Invokeservice(List<AppInvoker> toinvoke)
        {
            foreach (var invk in toinvoke)
                switch (invk.Name)
                {
                    case "Extract2":
                        // var procid = new Lib.Action().StartProcess(Util.Services.Claims);
                        //  long.TryParse(procid, out long pid);
                        // var res =
                        //Core core = new Core();

                        try
                        {
                            var response = Core.Push().GetAwaiter().GetResult();//.GetAwaiter().GetResult();

                            if (response.IsSuccess)
                            {
                                Console.WriteLine("Push was successful.");

                            }
                            else
                            {
                                Console.WriteLine("Push failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                        //  new Lib.Action().EndProcess(pid, Util.Services.Claims, res.data.Select(d => d.processorIDTransactionID).ToList());
                        break;

                    case "Extract":
                        //var procid = new Lib.Action().StartProcess(Util.Services.Claims);
                        //long.TryParse(procid, out long pid);
                        //var res =
                        SettlementNotification settlementNotification = new SettlementNotification();

                        try
                        {
                            var response = settlementNotification.SettlementNotify().GetAwaiter().GetResult();//.GetAwaiter().GetResult();
                            if (response.IsSuccess || response.Data != null)
                            {
                                Console.WriteLine("Settlement notification was successful.");

                            }
                            else
                            {
                                Console.WriteLine("Settlement notification failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                        //  new Lib.Action().EndProcess(pid, Util.Services.Claims, res.data.Select(d => d.processorIDTransactionID).ToList());
                        break;

                    case "Extract1":
                        //var procid = new Lib.Action().StartProcess(Util.Services.Claims);
                        //long.TryParse(procid, out long pid);
                        //var res =
                        SettlementStatus settlementStatus = new SettlementStatus();

                        try
                        {
                            var response = settlementStatus.SettlementStats().GetAwaiter().GetResult();//.GetAwaiter().GetResult();
                            if (response.IsSuccess || response.Data != null)
                            {
                                Console.WriteLine("Settlement status was successful.");

                            }
                            else
                            {
                                Console.WriteLine("Settlement status failed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }

                        //  new Lib.Action().EndProcess(pid, Util.Services.Claims, res.data.Select(d => d.processorIDTransactionID).ToList());
                        break;
                }
            return "";
        }

    }
}
