using System.Diagnostics;

namespace Bhop.SDK.YaamiSDK
{
    public class Minecraft
    {
        /// <summary>
        /// Minecraft LocalPlayer (Main class!)
        /// </summary>
        public static LocalPlayer lp
        { get => new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_offsets))); }

        /// <summary>
        /// Mostly useless (EXPECT FOR RAPID HIT/PLACE!)
        /// Hit/Placing
        /// </summary>
        public static VanillaInput vi
        { get => new VanillaInput(MCM.baseEvaluatePointer(SDK_PS_Offsets.vanillaInput, SDK_PS_Offsets.vanillaInput_offsets)); }

        /// <summary>
        /// Crash minecraft
        /// </summary>
        public static void crash() => Process.GetProcessesByName("Minecraft.Windows")[0].Kill();

        /// <summary>
        /// Fake packets for external clients
        /// </summary>
        public static vPackets ph => new vPackets();
    }
}
