using Bhop.gameHooks;

namespace Bhop.SDK.YaamiSDK
{
    public class VanillaInput // Perma fixes for getting if players hitting or placing !
    {
        public ulong addr;
        public VanillaInput(ulong addr) => this.addr = addr;

        /// <summary>
        /// Returns true if the local player is currently hitting/holding left click (Rapidly set to false for rapid hit!)
        /// </summary>
        public bool isHitting
        {
            get => MCM.GetAsyncKeyState((char)gh_Mouse.MouseEF.Hit);
            set => MCM.writeInt(addr + SDK_PS_Offsets.hitting_Hex, value ? 1 : 0);
        }

        /// <summary>
        /// Returns true if the local player is currently placing/holding right click (Rapidly set to false for rapid place!)
        /// </summary>
        public bool isPlacing
        {
            get => MCM.GetAsyncKeyState((char)gh_Mouse.MouseEF.Place);
            set => MCM.writeInt(addr + SDK_PS_Offsets.placing_Hex, value ? 1 : 0);
        }
    }
}
