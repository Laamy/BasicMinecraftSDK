using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.SDK.YaamiSDK
{
    public class VanillaInput
    {
        public ulong addr;
        public VanillaInput(ulong addr) => this.addr = addr;

        public bool isHitting
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.hitting_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.hitting_Hex, value ? 1 : 0);
        }

        public bool isPlacing
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.placing_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.placing_Hex, value ? 1 : 0);
        }
    }
}
