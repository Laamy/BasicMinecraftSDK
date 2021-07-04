using System.Diagnostics;

namespace Bhop.SDK.YaamiSDK
{
    public class Minecraft
    {
        // Predefined Classes
        public static LocalPlayer lp
        { get => new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, SDK_PS_Offsets.localPlayer_offsets)); }
        public static VanillaInput vi
        { get => new VanillaInput(MCM.baseEvaluatePointer(SDK_PS_Offsets.vanillaInput, SDK_PS_Offsets.vanillaInput_offsets)); }

        // Single pointers
        public static bool isSprinting
        { set => MCM.writeInt(MCM.baseEvaluatePointer(SDK_PS_Offsets.sprinting, SDK_PS_Offsets.sprinting_offsets), value ? 1 : 0); }

        // Other Voids
        public static void crash() => Process.GetProcessesByName("Minecraft.Windows")[0].Kill();
    }
}
