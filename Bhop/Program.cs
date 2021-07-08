using System;
using System.Diagnostics;

using Bhop.SDK.YaamiSDK; // Bhop SDK imports
using Bhop.SDK;
using Bhop.gameHooks;
using Bhop.IO;
using System.Threading;

namespace Bhop
{
    class Program
    {
        public static EventHandler<EventArgs> mainLoop;
        static void Main(string[] args)
        {
            try
            {
                if (Process.GetProcessesByName("Minecraft.Windows")[0] != null)
                    Process.GetProcessesByName("Minecraft.Windows")[0].Kill();
            }
            catch { }

            Process.Start("minecraft://");

            MCM.openGame();
            MCM.openWindowHost();

            keyHooks kh = new keyHooks();

            if (!YaamiIO.hasConfig()) // Setup config
            {
                YaamiIO.saveConfig(YaamiIO.dataFileName);
            }
            else
            {
                YaamiIO.loadConfig(YaamiIO.dataFileName);
            }

            Utils.sigScanThread(() => {
                while (true)
                {
                    Thread.Sleep(5000);
                    YaamiIO.saveConfig(YaamiIO.dataFileName);
                }
            });

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
                Minecraft.lp.velocity.y = 0.1f;
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



            if (keyHooks.keyBoolean('R'))
                Minecraft.lp.playerAABB.moveTo(new Vec3(1, 1, 1));



            Minecraft.ph.sprint(); // Send sprint vPacket

        }
    }
}
