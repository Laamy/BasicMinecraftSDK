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

            keyHooks kh = new keyHooks();

            mainLoop += gameTick;

            SDK_PS_Offsets.findOffsets(); // THIS TAKES A LITTLE WHILE!

            while (true)
            {
                mainLoop.Invoke(null, new EventArgs());
            }
        }

        private static void gameTick(object sender, EventArgs e) // Put your code inside this function!
        {
            if (Minecraft.lp.isNull) return; // Dont run code when local player is null

            if (Minecraft.lp.inWater) // jesus hacks
            {
                Minecraft.lp.velocity.y = 0.15f;
                Minecraft.lp.onGround = true;
            }

            if (Minecraft.lp.inElytraFlight) // Elytra Flight
            {
                if (keyHooks.keyBoolean('X'))
                {
                    Minecraft.lp.velocity.x = Minecraft.lp.velocity.x * 1.005f;
                    Minecraft.lp.velocity.y = Minecraft.lp.velocity.y * 1.005f;
                    Minecraft.lp.velocity.z = Minecraft.lp.velocity.z * 1.005f;
                }
            }

            if (Minecraft.lp.isDead) // Death Coords
            {
                var vec = Minecraft.lp.playerAABB.AA;
                Console.WriteLine("You died at " + vec.x + "," + vec.y + "," + vec.z);
            }

        }
    }
}
