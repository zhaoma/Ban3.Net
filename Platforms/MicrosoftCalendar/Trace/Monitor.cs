using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Trace
{
    public class Monitor<T>
    {
        public Dictionary<string, Record> Records { get; set; }

        public Monitor()
        {
            //typeof( T ).DataPath();
        }

        private static ReaderWriterLockSlim WriteLock = new ReaderWriterLockSlim();
    }
}