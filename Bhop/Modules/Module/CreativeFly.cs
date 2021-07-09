using Bhop.SDK.YaamiSDK;

namespace Bhop.Modules.Module
{
    public class CreativeFly : Mod
    {
        public CreativeFly() : base("CreativeFly", "Base") { }

        public override void onLoop()
        {
            if (enabled)
            {
                if (Minecraft.lp.isNull) return;

                Minecraft.lp.isFlying = true;
            }
        }
    }
}
