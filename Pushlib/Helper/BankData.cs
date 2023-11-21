using System.Collections.Generic;

namespace dmslib
{
    public class DDataObj<T>
    {
        public DDataObj()
        {
            ldata = new List<T>();
        }
        public List<T> ldata { get; set; }
        public T Data { get; set; }
        public string Objson { get; set; }
    }

    //public class MultiDataObj<T> : DDataObj<T>
    //{
    //    public MultiDataObj()
    //    {
    //        lairdata = new List<AIRBatch>();
    //    }
    //    public List<AIRBatch> lairdata { get; set; }
    //}

    public class BankData
    {
        public string BANKCODE { get; set; }
        public string BIN { get; set; }
        public string RAWDATARECIEPIENT { get; set; }
        public string BANKNAME { get; set; }
        public string BANKFIID { get; set; }
        public string BANKFULLNAME { get; set; }
        public string BUSINESSTYPE { get; set; }
        public string ACQUIRERFIID { get; set; }
        public string DESTIIN { get; set; }
        public string CBNCODE { get; set; }
        public string Bankcardname { get; set; }
    }

    public class Orig
    {
        public string Origid { get; set; }
        public string Scheme { get; set; }
        public string Channel { get; set; }
    }
}
