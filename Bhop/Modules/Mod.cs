using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.Modules
{
    public abstract class Mod
    {
        public string name;
        public string category;

        public bool enabled;
        public bool lastEnabled;

        public Mod(string name, string category)
        {
            this.name = name;
            this.category = category;
            enabled = false;
            ModHandle.handle.modules.Add(this);
        }

        public virtual void onLoop()
        {

        }
    }
}
