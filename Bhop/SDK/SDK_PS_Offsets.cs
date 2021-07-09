using Bhop.SDK.YaamiSDK;
using System;

namespace Bhop.SDK
{
    class SDK_PS_Offsets
    {
        // Statics
        public static ulong reach_Hex = 0x0;

        public static ulong vanillaInput = 0x03FE4618;
        public static UInt64[] vanillaInput_offsets = { 0x0, 0x4D0, 0x2A0, 0x8, 0x0 };
        public static ulong
            hitting_Hex = 0x50,
            placing_Hex = hitting_Hex + 1;

        public static ulong localPlayer = 0x04020228;
        public static string localPlayer_offsets = "0 18 B8 ";
        public static string gameDim_offsets = "370 0";
        public static ulong // localPlayer
            bodyRots_Hex = 0x0,
            Step_Hex = 0x0,
            Type_Hex = 0x410, // Currently useless
            PositionX_Hex = 0x0,
            WorldAge_Hex = 0x2B0,
            Gamemode_Hex = 0x1E08,
            isFlying_Hex = 0x9C0,
            BlocksTraveled_Ex_Hex = 0x250,
            BlocksTraveled_Hex = BlocksTraveled_Ex_Hex + 16,
            Hitbox_Hex = 0x0, // Hitbox should always be 28 bytes from the X Position
            VelocityX_Hex = 0x0,
            SwingAn_Hex = 0x0,
            heldItemCount_Hex = 0x228A,
            viewCreativeItems = 0x9D8,
            inInventory = 0x11E0,
            Username_Hex = 0x920, // Currently useless
            LookingEntityID_Hex = 0x0,
            inWater_Hex = 0x0,
            onGround_Hex = 0x0,
            gameDim_Hex = 0x18; // gameDim class
            

        /// <summary>
        /// Scan for sigs inside of minecraft for the new local player offsets
        /// </summary>
        public static void findOffsets() // Sig scans to find the new offsets
        {
            SigScanSharp MCRM = new SigScanSharp(MCM.mcProcHandle);
            MCRM.SelectModule(MCM.mcProc.MainModule);
            long storeSig;

            Console.WriteLine("Please wait until all the sigs have been found! (Searching...)");

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F B6 80 ? ? ? ? C3 CC CC CC CC 48 8B 41 ? F3", out storeSig) + 3;
                Console.WriteLine("Found onGround_Hex " + MCM.readInt(addr).ToString("X"));
                onGround_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F3 0F 10 ? ? ? ? ? C3 CC CC CC 48 8B 41 ? 88 90 ? ? ? ? C3", out storeSig) + 4;
                Console.WriteLine("Found Step_Hex " + MCM.readInt(addr).ToString("X"));
                Step_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F2 0F 11 87 ? ? ? ? F3 0F 10 8F ? ? ? ? F3", out storeSig) + 4;
                Console.WriteLine("Found bodyRots_Hex " + (MCM.readInt(addr) - 4).ToString("X"));
                bodyRots_Hex = Convert.ToUInt64(MCM.readInt(addr) - 4);
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("F3 0F 10 81 ? ? ? ? 41 0F 2F", out storeSig) + 4;
                Console.WriteLine("Found PositionX_Hex " + MCM.readInt(addr).ToString("X"));
                PositionX_Hex = Convert.ToUInt64(MCM.readInt(addr));

                Console.WriteLine("Position addition sig Hitbox_Hex " + (MCM.readInt(addr) + 28).ToString("X"));
                Hitbox_Hex = Convert.ToUInt64(MCM.readInt(addr) + 28);
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F 10 89 ? ? ? ? 0F 57 D2 F3 0F ? ? ? ? ? ? 0F 28 C1 0F", out storeSig) + 3;
                Console.WriteLine("Found VelocityX_Hex " + MCM.readInt(addr).ToString("X"));
                VelocityX_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("48 39 9F ? ? ? ? 0F 95", out storeSig) + 3;
                Console.WriteLine("Found LookingEntityID_Hex " + MCM.readInt(addr).ToString("X"));
                LookingEntityID_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("80 BB ? ? ? ? 00 74 1A FF", out storeSig) + 2;
                Console.WriteLine("Found SwingAn_Hex " + MCM.readInt(addr).ToString("X"));
                SwingAn_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("0F B6 81 ? ? ? ? C3 CC CC CC CC CC CC CC ? 0F B6 81 ? ? ? ? C3 CC CC CC CC CC CC CC CC 48 89 5C 24 18", out storeSig) + 3;
                Console.WriteLine("Found inWater_Hex " + MCM.readInt(addr).ToString("X"));
                inWater_Hex = Convert.ToUInt64(MCM.readInt(addr));
            });

            // Static sigs

            Utils.sigScanThread(() => {
                ulong addr = MCRM.FindPattern("00 00 40 40 DB 0F", out storeSig);
                Console.WriteLine("Found reach_Hex static " + addr.ToString("X"));
                reach_Hex = addr;
            });
        }
    }
}
