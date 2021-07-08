using System;
using System.Threading;

namespace Bhop.SDK.YaamiSDK
{
    class Utils
    {
        /// <summary>
        /// Presetup thread I use for sig scanning
        /// </summary>
        /// <param name="func"> Void/Function/Action
        /// sigScanThread(() => {
        ///     // Code here!
        /// });</param>
        public static void sigScanThread(Action func)
        {
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                func();
            }).Start();
        }
    }
}
