using System;
using System.Collections.Generic;

namespace Bhop.Modules.Command
{
    class Modules : Cmd
    {
        public Modules() : base("Modules") { }

        public override void executed(string[] args)
        {
            foreach (Mod mod in ModHandle.handle.modules)
                Console.WriteLine($"{mod.name} [{mod.category}] [{mod.enabled}]");
            Console.WriteLine("\r\n");
        }
    }
}
