using System;
using System.Threading;

namespace Bhop.SDK.YaamiSDK
{
    class Utils
    {
        public static void sigScanThread(Action func)
        {
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                func();
            }).Start();
        }
    }
}
