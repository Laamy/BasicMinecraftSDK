using Bhop.SDK.YaamiSDK;
using System;

namespace Bhop.SDK
{
    class SDK_PS_Offsets
    {
        // Statics
        public static ulong reach_Hex = 0x0;

        // Pointers
        public static ulong sprinting = 0x03F11820;
        public static UInt64[] sprinting_offsets = { 0x98, 0x138, 0xF0, 0x8, 0x1C0, 0x8, 0x9EC };

        public static ulong vanillaInput = 0x03FE4618;
        public static UInt64[] vanillaInput_offsets = { 0x0, 0x4D0, 0x2A0, 0x8, 0x0 };
        public static ulong
            hitting_Hex = 0x50,
            placing_Hex = hitting_Hex + 1;

        public static ulong localPlayer = 0x04020228;
        public static UInt64[] localPlayer_offsets = { 0x0, 0x18, 0xB8, 0x0 };
        public static ulong bodyRots_Hex = 0x0, // localPlayer
            Step_Hex = 0x0,
            Level_Hex = 0x0,
            Type_Hex = 0x410,
            PositionX_Hex = 0x0,
            Hitbox_Hex = 0x4EC,
            VelocityX_Hex = 0x0,
            SwingAn_Hex = 0x0,
            Username_Hex = 0x920,
            LookingEntityID_Hex = 0x0,
            inWater_Hex = 0x0,
            onGround_Hex = 0x0;

        public static void findOffsets() // Sig scans to find the new offsets
        {
            SigScanSharp MCRM = new SigScanSharp(MCM.mcProcHandle);
            MCRM.SelectModule(MCM.mcProc.MainModule);
            long storeSig;

            Console.WriteLine("Please wait until all the sigs have been found! (Searching...)");

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F B6 80 ? ? ? ? C3 CC CC CC CC 48 8B 41 ? F3", out storeSig) + 3;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                onGround_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F3 0F 10 ? ? ? ? ? C3 CC CC CC 48 8B 41 ? 88 90 ? ? ? ? C3", out storeSig) + 4;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                Step_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F2 0F 11 87 ? ? ? ? F3 0F 10 8F ? ? ? ? F3", out storeSig) + 4;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                bodyRots_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F3 0F 10 81 ? ? ? ? 41 0F 2F", out storeSig) + 4;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                PositionX_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F 10 89 ? ? ? ? 0F 57 D2 F3 0F ? ? ? ? ? ? 0F 28 C1 0F", out storeSig) + 3;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                VelocityX_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("48 39 9F ? ? ? ? 0F 95", out storeSig) + 3;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                LookingEntityID_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("48 8B 8F ? ? ? ? 48 8B 11 FF 92 ? ? ? ? 48 8B 8F ? ? ? ? 48 8B", out storeSig) + 3;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                Level_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("80 BB ? ? ? ? 00 74 1A FF", out storeSig) + 2;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                SwingAn_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F B6 81 ? ? ? ? C3 CC CC CC CC CC CC CC ? 0F B6 81 ? ? ? ? C3 CC CC CC CC CC CC CC CC 48 89 5C 24 18", out storeSig) + 3;
                Console.WriteLine("Found offset " + MCM.readInt(addr).ToString("X"));
                inWater_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            // Static sigs

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("00 00 40 40 DB 0F", out storeSig);
                Console.WriteLine("Found static " + addr.ToString("X"));
                reach_Hex = addr;
            });
        }
    }
}
