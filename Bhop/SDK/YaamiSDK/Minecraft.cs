﻿using System.Diagnostics;

namespace Bhop.SDK.YaamiSDK
{
    public class Minecraft
    {
        // Predefined Classes
        public static LocalPlayer lp
        { get => new LocalPlayer(MCM.baseEvaluatePointer(SDK_PS_Offsets.localPlayer, MCM.ceByte2uLong(SDK_PS_Offsets.localPlayer_offsets))); }
        public static VanillaInput vi
        { get => new VanillaInput(MCM.baseEvaluatePointer(SDK_PS_Offsets.vanillaInput, SDK_PS_Offsets.vanillaInput_offsets)); }

        // Other Voids
        public static void crash() => Process.GetProcessesByName("Minecraft.Windows")[0].Kill();

        // Custom Defined Classes
        public static vPackets ph => new vPackets();
    }
}
