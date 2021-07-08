using Bhop.gameHooks;
using System;

namespace Bhop.SDK.YaamiSDK
{
    public class vPackets // Fake packets
    {
        /// <summary>
        /// Send the middle click key on the mouse
        /// </summary>
        public bool copyBlock() => gh_Mouse.sendAction(gh_Mouse.MouseEF.CopyBlock);

        /// <summary>
        /// Send the right click key on the mouse
        /// </summary>
        public bool place() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Place);

        /// <summary>
        /// Send the left click key on the mouse
        /// </summary>
        public bool hit() => gh_Mouse.sendAction(gh_Mouse.MouseEF.Hit);

        /// <summary>
        /// Send the control click key on the keyboard
        /// </summary>
        public bool sprint() => gh_keyboard.sendAction(gh_keyboard.KeyboardEF.Sprinting);

        /// <summary>
        /// Equal To(=>) moveForwards(4);
        /// </summary>
        public bool walk() => moveForwards(4);

        /// <summary>
        /// Move a customize amount of toks forwards for auto walk baritone etc.
        /// </summary>
        /// <param name="toks">Customized unit for moving forwards unqie to this program</param>
        /// <returns></returns>
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
