using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.SDK.YaamiSDK
{
    class MinecraftEvents
    {
        public static EventHandler<plrEvent> /// Events
            onDeath,
            onJump,
            enterElytraFlight,
            enterWater,
            onMoveForwards;

        public static void invokeSetup()
        {
            Program.mainLoop += tick;
        }

        public static bool[] lastTick_Data = { false, false, false, false, false };

        private static void tick(object sender, EventArgs e)
        {
            try
            {

                if (Minecraft.lp.isDead && lastTick_Data[0] == false)
                    onDeath.Invoke(null, new plrEvent(Minecraft.lp));
                lastTick_Data[0] = Minecraft.lp.isDead;

                /*if (Minecraft.lp.onGround && lastTick_Data[1] == false)
                    onJump.Invoke(null, new plrEvent(Minecraft.lp));
                lastTick_Data[1] = Minecraft.lp.onGround;

                if (Minecraft.lp.inElytraFlight && lastTick_Data[2] == false)
                    enterElytraFlight.Invoke(null, new plrEvent(Minecraft.lp));
                lastTick_Data[2] = Minecraft.lp.inElytraFlight;

                if (Minecraft.lp.inWater && lastTick_Data[3] == false)
                    enterWater.Invoke(null, new plrEvent(Minecraft.lp));
                lastTick_Data[3] = Minecraft.lp.inWater;

                if (keyHooks.keyBoolean('W') && lastTick_Data[4] == false)
                    onMoveForwards.Invoke(null, new plrEvent(Minecraft.lp));
                lastTick_Data[4] = keyHooks.keyBoolean('W');*/

            }
            catch { }
        }
    }
    public class plrEvent : EventArgs
    {
        public AABB position;
        public plrEvent(LocalPlayer lp) => this.position = lp.playerAABB;
    }
}
