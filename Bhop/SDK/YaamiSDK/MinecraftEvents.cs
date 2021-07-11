using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhop.SDK.YaamiSDK
{
    class MinecraftEvents
    {
        public static EventHandler<deathEventArgs> onDeath; // Perfect!
        public static EventHandler<jumpEventArgs> onJump; // Slow ;-;
        public static EventHandler<enterWaterEventArgs> enterWater; // nearly there...
        public static EventHandler<moveForwardsEventArgs> onMoveForwards; // Unsure ;-;
        public static EventHandler<enterFlightEventArgs> enterFlight; // Should be perfect like ondeath due to how it works lmao
        public static EventHandler<changedWorldEventArgs> changedWorld; // Perfect!

        public static void invokeSetup()
        {
            Program.mainLoop += tick;

            onDeath += _1eventCap;
            onJump += _1eventCap;
            enterWater += _1eventCap;
            onMoveForwards += _1eventCap;
            enterFlight += _1eventCap;
            changedWorld += _1eventCap;
        }

        private static void _1eventCap(object sender, EventArgs e) { }

        public static bool _1lastTick_Data = false;
        public static bool _2lastTick_Data = false;
        public static bool _3lastTick_Data = false;
        public static bool _4lastTick_Data = false;
        public static bool _5lastTick_Data = false;
        public static string _6lastTick_Data = "";

        private static void tick(object sender, EventArgs e)
        {
            if (Minecraft.lp.isNull) return;

            try
            {

                if (Minecraft.lp.isDead && _1lastTick_Data == false)
                    onDeath.Invoke(null, new deathEventArgs(Minecraft.lp));
                _1lastTick_Data = Minecraft.lp.isDead;

                if (Minecraft.lp.onGround && _2lastTick_Data == false)
                    onJump.Invoke(null, new jumpEventArgs(Minecraft.lp));
                _2lastTick_Data = Minecraft.lp.onGround;

                if (Minecraft.lp.inWater && _4lastTick_Data == false)
                    enterWater.Invoke(null, new enterWaterEventArgs(Minecraft.lp));
                _4lastTick_Data = Minecraft.lp.inWater;

                if (keyHooks.keyBoolean('W') && _5lastTick_Data == false)
                    onMoveForwards.Invoke(null, new moveForwardsEventArgs(Minecraft.lp));
                _5lastTick_Data = keyHooks.keyBoolean('W');

                if (Minecraft.lp.isFlying && _5lastTick_Data == false)
                    enterFlight.Invoke(null, new enterFlightEventArgs(Minecraft.lp));
                _5lastTick_Data = Minecraft.lp.isFlying;

                if (Minecraft.lp.isFlying && _6lastTick_Data != Minecraft.lp.dimension)
                    changedWorld.Invoke(null, new changedWorldEventArgs(Minecraft.lp));
                _6lastTick_Data = Minecraft.lp.dimension;

            }
            catch { }
        }
    }
    public class deathEventArgs : EventArgs
    {
        public AABB position;
        public deathEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
    public class jumpEventArgs : EventArgs
    {
        public AABB position;
        public jumpEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
    public class enterWaterEventArgs : EventArgs
    {
        public AABB position;
        public enterWaterEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
    public class moveForwardsEventArgs : EventArgs
    {
        public AABB position;
        public moveForwardsEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
    public class enterFlightEventArgs : EventArgs
    {
        public AABB position;
        public enterFlightEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
    public class changedWorldEventArgs : EventArgs
    {
        public AABB position;
        public changedWorldEventArgs(LocalPlayer lp) => this.position = lp.playerAABB;
    }
}
