using Bhop.SDK.YaamiSDK;

namespace Bhop.Modules.Module
{
    public class AirJump : Mod
    {
        public AirJump() : base("AirJump", "Base") { }

        public override void onLoop()
        {
            if (enabled)
            {
                if (Minecraft.lp.isNull) return;

                Minecraft.lp.onGround = true;
            }
        }
    }
}
