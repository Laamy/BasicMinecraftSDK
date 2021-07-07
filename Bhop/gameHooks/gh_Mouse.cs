using System;
using System.Runtime.InteropServices;

namespace Bhop.gameHooks
{
    class gh_Mouse
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [Flags]
        public enum MouseEF
        {
            Hit = 0x02,
            Place = 0x08,
            CopyBlock = 0x20,
        }

        public static bool sendAction(MouseEF keyFlag)
        {
            if (MCM.isMinecraftFocused())
            {
                if (keyFlag == MouseEF.Hit)
                {
                    mouse_event(0x02, 0, 0, 0, 0);
                    mouse_event(0x04, 0, 0, 0, 0);
                }
                else if (keyFlag == MouseEF.Place)
                {
                    mouse_event(0x08, 0, 0, 0, 0);
                    mouse_event(0x10, 0, 0, 0, 0);
                }
                else if (keyFlag == MouseEF.CopyBlock)
                {
                    mouse_event(0x20, 0, 0, 0, 0);
                    mouse_event(0x40, 0, 0, 0, 0);
                }
                return true;
            }
            return false;
        }
    }
}
