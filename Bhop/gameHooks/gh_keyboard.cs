using System;
using System.Windows.Forms;

namespace Bhop.gameHooks
{
    class gh_keyboard // Ill redo this later i just realized how stupid it is...
    {
        [Flags]
        public enum KeyboardEF
        {
            Sprinting = 0x17,
            Forwards = 0x57,
            Left = 0x41,
            Backwards = 0x53,
            Right = 0x44,
        }

        /// <summary>
        /// Send custom keyboard action
        /// </summary>
        /// <param name="keyFlag"></param>
        /// <returns>Returns false if fails</returns>
        public static bool sendAction(KeyboardEF keyFlag)
        {
            if (MCM.isMinecraftFocused())
            {
                if (keyFlag == KeyboardEF.Sprinting)
                {
                    if (MCM.GetAsyncKeyState('W'))
                        SendKeys.SendWait("^");
                }
                else if (keyFlag == KeyboardEF.Forwards)
                {
                    SendKeys.SendWait("W");
                }
                else if (keyFlag == KeyboardEF.Left)
                {
                    SendKeys.SendWait("A");
                }
                else if (keyFlag == KeyboardEF.Backwards)
                {
                    SendKeys.SendWait("S");
                }
                else if (keyFlag == KeyboardEF.Right)
                {
                    SendKeys.SendWait("D");
                }
                return true;
            }
            return false;
        }
    }
}
