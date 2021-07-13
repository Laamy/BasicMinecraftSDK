using Bhop.SDK;
using Bhop.SDK.YaamiSDK;
using System;
using System.Collections.Generic;

namespace Bhop.Modules.Module
{
    public class TestModule : Mod
    {
        public TestModule() : base("TestModule", "Base") { }

        public override void onLoop()
        {
            if (keyHooks.keyBoolean('V'))
            {
                var cent = Minecraft.lp.getClosestPlayer();
                if (cent == null) return;

                Vec2 screenRots = Minecraft.lp.WorldToScreen(cent, 110);
                Console.WriteLine(screenRots.x + " " + screenRots.y);
            }
        }
    }
}
