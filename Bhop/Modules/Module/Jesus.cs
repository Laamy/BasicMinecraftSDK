using Bhop.SDK.YaamiSDK;

namespace Bhop.Modules.Module
{
    public class Jesus : Mod
    {
        public Jesus() : base("Jesus", "Base") { }

        public override void onLoop()
        {
            if (enabled)
            {
                if (Minecraft.lp.isNull) return;

                if (Minecraft.lp.inWater)
                {
                    Minecraft.lp.onGround = true;
                    Minecraft.lp.velocity.y = 0.1f;
                }
            }
        }
    }
}
