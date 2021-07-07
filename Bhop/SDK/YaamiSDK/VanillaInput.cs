using Bhop.gameHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.SDK.YaamiSDK
{
    public class VanillaInput // Perma fixes for getting if players hitting or placing !
    {
        public ulong addr;
        public VanillaInput(ulong addr) => this.addr = addr;

        public bool isHitting
        {
            get => MCM.GetAsyncKeyState((char)gh_Mouse.MouseEF.Hit);
            set => MCM.writeInt(addr + SDK_PS_Offsets.hitting_Hex, value ? 1 : 0);
        }

        public bool isPlacing
        {
            get => MCM.GetAsyncKeyState((char)gh_Mouse.MouseEF.Place);
            set => MCM.writeInt(addr + SDK_PS_Offsets.placing_Hex, value ? 1 : 0);
        }
    }
}
