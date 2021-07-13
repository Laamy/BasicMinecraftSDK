using Bhop.SDK.YaamiSDK;
using System;

namespace Bhop.Modules.Command
{
    class Teleportation : Cmd
    {
        public Teleportation() : base("Tp") { }

        public override void executed(string[] args)
        {
            if (args.Length == 4)
            {
                try
                {
                    Vec3i tempPos = new Vec3i(Convert.ToSingle(args[1]), Convert.ToSingle(args[2]), Convert.ToSingle(args[3]));
                    Minecraft.lp.setPos(tempPos);
                }
                catch
                {
                    DBG.error("Arguments are floats only");
                }
            }
            else DBG.error("Incorrect amount of arguments");
        }
    }
}
