using Bhop.Modules.Command;
using Bhop.Modules.Module;
using System;
using System.Collections.Generic;

namespace Bhop.Modules
{
    public class ModHandle
    {
        /// <summary>
        /// Moduel handler
        /// </summary>
        public static ModHandle handle;

        /// <summary>
        /// Modules list
        /// </summary>
        public List<Mod> modules = new List<Mod>();
        public List<Cmd> commands = new List<Cmd>();

        public ModHandle()
        {
            handle = this;
            Console.WriteLine("Setting up mods");

            // Deal with modules VVV
            new AirJump();
            new CreativeFly();
            new DeathCoords();
            new Jesus();
            new Noclip();
            new Reach();

            // Deal with the commands VVV
            new Commands();
            new Command.Modules();
            new Teleportation();
            new Toggle();

            moduleThread();
        }

        /// <summary>
        /// Dont touch! Sets up the module handler thread
        /// </summary>
        public void moduleThread()
        {
            Program.mainLoop += (object sen, EventArgs e) => { loopModules(); };
            Console.WriteLine("Mod thread started!");
        }

        /// <summary>
        /// Send module loopModule ticks
        /// </summary>
        public void loopModules()
        {
            foreach (Mod module in ModHandle.handle.modules)
            {
                try
                {
                    module.onLoop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
