using Bhop.SDK.YaamiSDK;
using System;
using System.Threading;

namespace Bhop.Modules.Module
{
    public class Autosprint : Mod
    {
        public Autosprint() : base("Autosprint", "Base")
        {
            MinecraftEvents.onMoveForwards += playerMoveForwards;
        }

        private void playerMoveForwards(object sender, plrEvent e)
        {
            if (!Minecraft.lp.isNull)
            {
                Minecraft.ph.sprint();
            }
        }
    }
}
