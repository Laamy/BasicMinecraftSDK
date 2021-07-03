using System;

namespace Bhop.SDK
{
    class SDK_PS_Offsets
    {
        public static ulong sprinting = 0x03F11820;
        public static UInt64[] sprinting_offsets = { 0x98, 0x138, 0xF0, 0x8, 0x1C0, 0x8, 0x9EC };

        public static ulong vanillaInput = 0x03FE4618;
        public static UInt64[] vanillaInput_offsets = { 0x0, 0x4D0, 0x2A0, 0x8, 0x0 };
        public static ulong
            hitting_Hex = 0x50,
            placing_Hex = hitting_Hex + 1;

        public static ulong localPlayer = 0x04020228;
        public static UInt64[] localPlayer_offsets = { 0x0, 0x18, 0xB8, 0x0 };
        public static ulong bodyRots_Hex = 0x140, // localPlayer
            Step_Hex = 0x240,
            Level_Hex = 0x378,
            Type_Hex = 0x410,
            PositionX_Hex = 0x4D0,
            Hitbox_Hex = 0x4EC,
            VelocityX_Hex = 0x50C,
            SwingAn_Hex = 0x7A0,
            Username_Hex = 0x920,
            LookingEntityID_Hex = 0x10B8,
            inWater_Hex = 0x265,
            onGround_Hex = 0x1E0;
    }
}
