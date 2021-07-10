using Bhop.SDK.YaamiSDK;
using System;

namespace Bhop.Modules.Command
{
    class Gamemode : Cmd
    {
        public Gamemode() : base("Gm") { }

        public override void executed(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    if (Convert.ToSingle(args[1]) == 0)
                        Minecraft.lp.gamemode = LocalPlayer.Gamemode.Survival;
                    if (Convert.ToSingle(args[1]) == 1)
                        Minecraft.lp.gamemode = LocalPlayer.Gamemode.Creative;
                    if (Convert.ToSingle(args[1]) == 2)
                        Minecraft.lp.gamemode = LocalPlayer.Gamemode.Adventure;
                }
                catch
                {
                    DBG.error("Arguments are int only");
                }
            }
            else DBG.error("Incorrect amount of arguments");
        }
    }
}
