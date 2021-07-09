using System;
using System.Collections.Generic;

namespace Bhop.Modules.Command
{
    class Commands : Cmd
    {
        public Commands() : base("Cmds") { }

        public override void executed(string[] args)
        {
            foreach (Cmd cmd in ModHandle.handle.commands)
                Console.WriteLine($"{cmd.name}");
            Console.WriteLine("\r\n");
        }
    }
}
