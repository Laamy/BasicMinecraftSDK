using Bhop.gameHooks;
using System;

namespace Bhop.SDK.YaamiSDK
{
    public class vPackets // Fake packets
    {
        public bool copyBlock() => gh_Mouse.sendAction(gh_Mouse.MouseEF.CopyBlock);
        public bool place() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Place);
        public bool hit() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Hit);

        public bool sprint() => gh_keyboard.sendAction(gh_keyboard.KeyboardEF.Sprinting);

        public bool walk() => moveForwards(4);

        public bool moveForwards(float toks)
        {
            var longpoo = Minecraft.lp;
            if (!longpoo.isNull)
            {
                float calcYaw = (longpoo.bodyRots.x + 90F) * ((float)Math.PI / 180F);
                longpoo.velocity.x = (float)Math.Cos(calcYaw) * (toks / 9f);
                longpoo.velocity.z = (float)Math.Sin(calcYaw) * (toks / 9f);
                return true;
            }
            return false;
        }
    }
}
