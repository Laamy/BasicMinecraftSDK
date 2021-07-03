using System;
using System.Diagnostics;

using Bhop.SDK.YaamiSDK; // Bhop SDK imports
using Bhop.SDK;

namespace Bhop
{
    class Program
    {
        public static EventHandler<EventArgs> mainLoop;
        static void Main(string[] args)
        {
            /*if (Process.GetProcessesByName("Minecraft.Windows")[0] != null)
                Process.GetProcessesByName("Minecraft.Windows")[0].Kill();*/
            Process.Start("minecraft://");

            MCM.openGame();
            MCM.openWindowHost();

            KeybindHandler kh = new KeybindHandler();

            mainLoop += gameTick;

            SDK_PS_Offsets.findOffsets(); // THIS TAKES A LITTLE WHILE!

            while (true)
            {
                mainLoop.Invoke(null, new EventArgs());
            }
        }

        private static void gameTick(object sender, EventArgs e) // Put your code inside this function!
        {

            if (KeybindHandler.isKeyDown('V'))
            {
                Minecraft.lp.velocity.y = 0.1f;
            }

            if (Minecraft.lp.inWater)
            {
                Minecraft.lp.velocity.y = 0.1f;
                Minecraft.lp.onGround = true;
            }

        }
    }
}
