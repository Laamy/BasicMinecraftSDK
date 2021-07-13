using Bhop.SDK.YaamiSDK;

namespace Bhop.Modules.Module
{
    public class Noclip : Mod
    {
        public Noclip() : base("Noclip", "Base") { }

        public override void onLoop()
        {
            if (enabled && lastEnabled == false) // Module just got enabled
            {
                Minecraft.lp.setPos(new Vec3i(Minecraft.lp.playerAABB.AA.x, Minecraft.lp.playerAABB.AA.y - 3.6f, Minecraft.lp.playerAABB.AA.z));
                Minecraft.lp.playerAABB.AA.y = Minecraft.lp.playerAABB.BB.y + 1.8f;
            }

            if (lastEnabled && enabled == false) // Module just got disabled
            {
                Minecraft.lp.setPos(Minecraft.lp.playerAABB.AA);
            }

            if (enabled)
            {
                if (Minecraft.lp.isNull) return;

                Minecraft.lp.isFlying = true;
            }
            lastEnabled = enabled;
        }
    }
}
