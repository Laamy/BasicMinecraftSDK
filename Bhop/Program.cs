using System.Diagnostics;
using System.Threading;
using System;

using Bhop.SDK.YaamiSDK; // Bhop SDK imports
using Bhop.SDK;
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

            Console.ForegroundColor = ConsoleColor.Gray;

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
                        string[] _args = input.Split(' ');
                        bool validCommand = false;
                        foreach (Cmd cmd in ModHandle.handle.commands)
                            if (_args[0].ToUpper() == cmd.name.ToUpper())
                                validCommand = true;
                        if (validCommand)
                        {
                            foreach (Cmd cmd in ModHandle.handle.commands)
                                if (_args[0].ToUpper() == cmd.name.ToUpper())
                                    cmd.executed(_args);
                        }
                        else DBG.error("Invalid command?");
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
