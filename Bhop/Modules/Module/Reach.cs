using Bhop.SDK;
using Bhop.SDK.YaamiSDK;

namespace Bhop.Modules.Module
{
    public class Reach : Mod
    {
        public Reach() : base("Reach", "Base") { }

        public override void onLoop()
        {
            if (enabled && lastEnabled == false) // Module just got enabled
            {
                MCM.writeFloat(SDK_PS_Offsets.reach_Hex, 7f);
            }

            if (lastEnabled && enabled == false) // Module just got disabled
            {
                MCM.writeFloat(SDK_PS_Offsets.reach_Hex, 3f);
            }

            lastEnabled = enabled;
        }
    }
}
