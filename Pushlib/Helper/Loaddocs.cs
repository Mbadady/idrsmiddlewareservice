using dmslib;
using Syncfusion.XlsIO;
//using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dmscoreapi.Data
{
    public class Loaddocs
    {
        public List<BankData> LoadBanks(DataTable banksTable)
        {
            List<BankData> mcs = new List<BankData>();

            if (banksTable != null)
                foreach (DataRow cst in banksTable.Rows)
                {
                    BankData sd = new BankData()
                    {
                        BANKCODE = banksTable.Columns.Contains("BANKCODE") ? cst["BANKCODE"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        BIN = banksTable.Columns.Contains("BIN") ? cst["BIN"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        RAWDATARECIEPIENT = banksTable.Columns.Contains("RAWDATARECIEPIENT") ? cst["RAWDATARECIEPIENT"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        BANKNAME = banksTable.Columns.Contains("BANKNAME") ? cst["BANKNAME"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        BANKFIID = banksTable.Columns.Contains("BANKFIID") ? cst["BANKFIID"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        BANKFULLNAME = banksTable.Columns.Contains("BANKFULLNAME") ? cst["BANKFULLNAME"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        BUSINESSTYPE = banksTable.Columns.Contains("BUSINESSTYPE") ? cst["BUSINESSTYPE"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        ACQUIRERFIID = banksTable.Columns.Contains("ACQUIRERFIID") ? cst["ACQUIRERFIID"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        CBNCODE = banksTable.Columns.Contains("CBNCODE") ? cst["CBNCODE"].ToString().Trim().ToUpper().Replace("  ", " ") : ""
                    };
                    mcs.Add(sd);
                }
            return mcs;
        }

        public List<Orig> LoadOrigData(DataTable origTable)
        {
            List<Orig> mcs = new List<Orig>();
            if (origTable != null)
                foreach (DataRow cst in origTable.Rows)
                {
                    Orig sd = new Orig()
                    {
                        Origid = origTable.Columns.Contains("Origid") ? cst["Origid"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        Scheme = origTable.Columns.Contains("Scheme") ? cst["Scheme"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                        Channel = origTable.Columns.Contains("Channel") ? cst["Channel"].ToString().Trim().ToUpper().Replace("  ", " ") : "",
                    };
                    mcs.Add(sd);
                }
            return mcs;
        }

        public List<BankData> LoadDestIINBanks(DataTable banksTable, List<BankData> banks)
        {
            List<BankData> mcs = new List<BankData>();

            if (banksTable != null)
                foreach (DataRow cst in banksTable.Rows)
                {
                    var bankFIID = banksTable.Columns.Contains("BANKFIID") ? cst["BANKFIID"].ToString().Trim().ToUpper().Replace("  ", " ") : "";
                    if (!string.IsNullOrEmpty(bankFIID))
                    {
                        var sd = banks.FirstOrDefault(b => b.BANKFIID == bankFIID);
                        if (sd != null)
                        {
                            BankData bd = new BankData()
                            {
                                ACQUIRERFIID = sd.ACQUIRERFIID,
                                BANKCODE = sd.BANKCODE,
                                BANKFIID = sd.BANKFIID,
                                BANKFULLNAME = sd.BANKFULLNAME,
                                BANKNAME = sd.BANKNAME,
                                BIN = sd.BIN,
                                BUSINESSTYPE = sd.BUSINESSTYPE,
                                RAWDATARECIEPIENT = sd.RAWDATARECIEPIENT
                            };

                            bd.DESTIIN = banksTable.Columns.Contains("DESTIIN") ? cst["DESTIIN"].ToString().Trim().ToUpper().Replace("  ", " ") : "";
                            bd.Bankcardname = banksTable.Columns.Contains("Bank name") ? cst["Bank name"].ToString().Trim().ToUpper().Replace("  ", " ") : "";
                            mcs.Add(bd);
                        }
                    }
                }
            return mcs;
        }

        //public List<DataTable> LoadXls(string path, List<string> sheetnames)
        //{
        //    List<DataTable> tocodetable = new List<DataTable>();
        //    try
        //    {
        //        using (ExcelEngine excelEngine = new ExcelEngine())
        //        {
        //            IApplication application = excelEngine.Excel;
        //            application.DefaultVersion = ExcelVersion.Excel2016;
        //            IWorkbook workbook = application.Workbooks.OpenReadOnly(path);
        //            foreach (var sheetname in sheetnames)
        //            {
        //                IWorksheet worksheet = workbook.Worksheets[sheetname];
        //                tocodetable.Add(worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames));
        //            }
        //            workbook.Close();
        //            excelEngine.Dispose();
        //        }
        //    }
        //    catch (System.IO.FileNotFoundException ee)
        //    {
        //        Console.WriteLine(ee.Message);
        //        return null;
        //    }
        //    catch (Exception ee)
        //    {
        //        Console.WriteLine(ee.Message);
        //        return null;
        //    }

        //    return tocodetable;
        //}

 public List<DataTable> LoadXls(string path, List<string> sheetnames)
 {
            List<DataTable> tocodetable = new List<DataTable>();
            IWorkbook workbook = null;

        try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                workbook = application.Workbooks.Open(stream);

                foreach (var sheetname in sheetnames)
                {
                    IWorksheet worksheet = workbook.Worksheets[sheetname];
                    tocodetable.Add(worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames));
                }
            }
        }
    }
    catch (System.IO.FileNotFoundException ee)
    {
        Console.WriteLine(ee.Message);
        return null;
    }
    catch (Exception ee)
    {
        Console.WriteLine(ee.Message);
        return null;
    }
    finally
    {
        if (workbook != null)
        {
            workbook.Close();
        }
    }

    return tocodetable;
}


        public DataTable LoadXls(string path, byte[] xdoc = null, int indx = 0)
        {
            DataTable tocodetable;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {
                        IApplication application = excelEngine.Excel;
                        application.DefaultVersion = ExcelVersion.Excel2016;
                        IWorkbook workbook = xdoc != null ? application.Workbooks.Open(new System.IO.MemoryStream(xdoc))
                            : application.Workbooks.Open(stream);
                        IWorksheet worksheet = workbook.Worksheets[indx];
                        tocodetable = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                        workbook.Close();
                        excelEngine.Dispose();
                    }
                }
               
            }
            catch (System.IO.FileNotFoundException ee)
            {
                Console.WriteLine(ee.Message);
                return null;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return null;
            }

            return tocodetable;
        }

        //public string Importtoxls(EOD eod, string type, DateTime revdate)
        //{
        //    using (ExcelEngine excelEngine = new ExcelEngine())
        //    {
        //        IApplication application = excelEngine.Excel;
        //        application.DefaultVersion = ExcelVersion.Excel2013;
        //        IWorkbook workbook = application.Workbooks.Create(1);
        //        IWorksheet worksheet = workbook.Worksheets[0];

        //        //Import the data to worksheet
        //        worksheet.ImportData(eod.Reversals, 1, 1, true);
        //        // worksheet.

        //        if (type == "EOD")
        //        {
        //            try
        //            {
        //                workbook.Worksheets.Create("LastEODReversed");
        //                IWorksheet worksheet2 = workbook.Worksheets[1];
        //                worksheet2.ImportData(eod.LastEODReversed, 1, 1, true);


        //                workbook.Worksheets.Create("LastEODNotRversed");
        //                IWorksheet worksheet3 = workbook.Worksheets[2];
        //                worksheet3.ImportData(eod.LastEODNotRversed, 1, 1, true);


        //                workbook.Worksheets.Create("Cutoffs");
        //                IWorksheet worksheet4 = workbook.Worksheets[3];
        //                worksheet4.ImportData(eod.Cutoffs, 1, 1, true);
        //            }
        //            catch (Exception e)
        //            {

        //            }
        //        }

        //        string res = "ImportFromDT" + type + Util.Util.ConcatDate(revdate) + ".xlsx";
        //        workbook.SaveAs(Util.Constants.eodpath + res);
        //        return res;
        //    }
        //}
    }
}
