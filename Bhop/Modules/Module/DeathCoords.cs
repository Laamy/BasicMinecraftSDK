using Bhop.SDK.YaamiSDK;
using System;
using System.Threading;

namespace Bhop.Modules.Module
{
    public class DeathCoords : Mod
    {
        public DeathCoords() : base("DeathCoords", "Base")
        {
            Utils.sigScanThread(() => {
                Thread.Sleep(1000);
                if (enabled)
                {
                    if (!Minecraft.lp.isNull)
                        if (Minecraft.lp.isDead)
                        {
                            Console.WriteLine($"You died at {Minecraft.lp.playerAABB.AA.x}, {Minecraft.lp.playerAABB.AA.y}, {Minecraft.lp.playerAABB.AA.z}");
                        }
                }
            });
        }
    }
}
