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
            Process.Start("minecraft://");

            MCM.openGame();
            MCM.openWindowHost();

            KeybindHandler kh = new KeybindHandler();

            mainLoop += gameTick;

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
