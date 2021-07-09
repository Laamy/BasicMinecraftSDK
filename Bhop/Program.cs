using System.Diagnostics;
using System.Threading;
using System;

using Bhop.SDK.YaamiSDK; // Bhop SDK imports
using Bhop.SDK;
using Bhop.gameHooks;
using Bhop.IO;
using Bhop.Modules;

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

            ModHandle mh = new ModHandle();
            keyHooks kh = new keyHooks();

            if (!YaamiIO.hasConfig()) // Setup config
                YaamiIO.saveConfig(YaamiIO.dataFileName);
            else
                YaamiIO.loadConfig(YaamiIO.dataFileName);

            Utils.sigScanThread(() => {
                while (true)
                {
                    Thread.Sleep(5000);
                    YaamiIO.saveConfig(YaamiIO.dataFileName);
                }
            });

            Utils.sigScanThread(() => {
                while (true)
                {
                    if (SDK_PS_Offsets.reach_Hex != 0x0)
                    {
                        Console.Write("Mc_ModLauncher> ");
                        string input = Console.ReadLine();

                        if (input.ToUpper().StartsWith("TOGGLE "))
                        {
                            foreach (Mod mod in ModHandle.handle.modules)
                                if (mod.name.ToUpper() == input.ToUpper().Split(' ')[1])
                                {
                                    mod.enabled = !mod.enabled;
                                    Console.WriteLine($"{mod.name} [{mod.category}] [{mod.enabled}]\r\n");
                                }
                        }
                        else if (input.ToUpper() == "LIST")
                        {
                            foreach (Mod mod in ModHandle.handle.modules)
                                Console.WriteLine($"{mod.name} [{mod.category}] [{mod.enabled}]");
                            Console.WriteLine("\r\n");
                        }
                        else if (input.ToUpper() == "HELP")
                        {
                            Console.WriteLine("List - List mods");
                            Console.WriteLine("Toggle <name> - Toggle mods\r\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid command?\r\n");
                        }
                    }
                }
            });

            SDK_PS_Offsets.findOffsets(); // THIS TAKES A LITTLE WHILE!

            while (true)
            {
                try
                {
                    mainLoop.Invoke(null, new EventArgs());
                }
                catch { }
            }
        }
    }
}
