using System;
using System.Collections.Generic;

namespace Bhop.Modules.Command
{
    class Toggle : Cmd
    {
        public Toggle() : base("Toggle") { }

        public override void executed(string[] args)
        {
            if (args.Length == 2)
            {
                bool foundMod = false;
                foreach (Mod mod in ModHandle.handle.modules)
                    if (mod.name.ToUpper() == args[1].ToUpper())
                        foundMod = true;

                if (foundMod)
                {
                    foreach (Mod mod in ModHandle.handle.modules)
                        if (mod.name.ToUpper() == args[1].ToUpper())
                        {
                            mod.enabled = !mod.enabled;
                            Console.WriteLine($"{mod.name} [{mod.category}] [{mod.enabled}]\r\n");
                        }
                }
                else DBG.error("Invalid module");
            }
            else DBG.error("Incorrect amount of arguments");
        }
    }
}
