using Bhop.SDK.YaamiSDK;
using System;
using System.Threading;

namespace Bhop.Modules.Module
{
    public class DeathCoords : Mod
    {
        public DeathCoords() : base("DeathCoords", "Base")
        {
            MinecraftEvents.onDeath += playerDied;
        }

        private void playerDied(object sender, deathEventArgs e)
        {
            if (!Minecraft.lp.isNull && enabled)
            {
                Console.WriteLine($"You died at {Minecraft.lp.playerAABB.AA.x}, {Minecraft.lp.playerAABB.AA.y}, {Minecraft.lp.playerAABB.AA.z}");
            }
        }
    }
}
