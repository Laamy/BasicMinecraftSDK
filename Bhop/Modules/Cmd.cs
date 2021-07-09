using System.Collections.Generic;

namespace Bhop.Modules
{
    public abstract class Cmd
    {
        public string name;

        public Cmd(string name)
        {
            this.name = name;
            ModHandle.handle.commands.Add(this);
        }

        public virtual void executed(string[] args) { }
    }
}
