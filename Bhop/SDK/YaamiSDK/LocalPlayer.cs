using System;

namespace Bhop.SDK.YaamiSDK
{
    public class LocalPlayer
    {
        public ulong addr;
        public LocalPlayer(ulong addr) => this.addr = addr;

        #region outside localplayer
        public float reach
        {
            get => MCM.readFloat(SDK_PS_Offsets.reach_Hex);
            set => MCM.writeFloat(SDK_PS_Offsets.reach_Hex, value);
        }
        #endregion

        #region Defined vars
        public Vec2 bodyRots
        { get => new Vec2(addr + SDK_PS_Offsets.bodyRots_Hex); }

        public Vec2 hitbox
        { get => new Vec2(addr + SDK_PS_Offsets.Hitbox_Hex); }

        public float stepHeight
        {
            get => MCM.readFloat(addr + SDK_PS_Offsets.Step_Hex);
            set => MCM.writeFloat(addr + SDK_PS_Offsets.Step_Hex, value);
        }

        public string type
        {
            get => MCM.readString(addr + SDK_PS_Offsets.Type_Hex, 24);
            set => MCM.writeString(addr + SDK_PS_Offsets.Type_Hex, value);
        }

        public AABB playerAABB // Player positions (Minecraft has TWO! called the AABB I think idk tbh lel)
        { get => new AABB(addr + SDK_PS_Offsets.PositionX_Hex); }

        public Vec3 velocity
        { get => new Vec3(addr + SDK_PS_Offsets.VelocityX_Hex); }

        public int swingAnimation
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.SwingAn_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.SwingAn_Hex, value);
        }

        public string username
        {
            get => MCM.readString(addr + SDK_PS_Offsets.Username_Hex, 24);
            set => MCM.writeString(addr + SDK_PS_Offsets.Username_Hex, value);
        }

        public int lokingEntityID
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.LookingEntityID_Hex);
            set => MCM.writeInt(addr + SDK_PS_Offsets.LookingEntityID_Hex, value);
        }

        public bool inWater
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.inWater_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.inWater_Hex, value ? 1 : 0);
        }

        public bool onGround
        {
            get => MCM.readInt(addr + SDK_PS_Offsets.onGround_Hex) != 0;
            set => MCM.writeInt(addr + SDK_PS_Offsets.onGround_Hex, value ? 1 : 0);
        }
        #endregion

        #region Custom vars
        public bool isDead
        {
            get
            {
                if (hitbox.x <= 0.25 && hitbox.y <= 0.25)
                    return true;
                return false;
            }
        }
        public bool inElytraFlight
        {
            get
            {
                if (hitbox.x >= 0.5 && hitbox.y >= 0.5 && hitbox.x <= 0.65 && hitbox.y <= 0.65 && onGround == false)
                    return true;
                return false;
            }
        }
        public bool isMoving
        {
            get
            {
                if (keyHooks.keyBoolean('W') || keyHooks.keyBoolean('A') || keyHooks.keyBoolean('S') || keyHooks.keyBoolean('D') || keyHooks.keyBoolean((char)0x20))
                    return true;
                return false;
            }
        }
        public bool isNull
        {
            get
            {
                if (playerAABB.AA.x == 0 && playerAABB.BB.x == 0 && playerAABB.AA.y == 0 && playerAABB.BB.y == 0 && playerAABB.AA.z == 0 && playerAABB.BB.z == 0
                    && hitbox.x == 0f && hitbox.y == 0f && bodyRots.x == 0f && bodyRots.y == 0f)
                    return true;
                return false;
            }
        }
        #endregion

        #region Defined voids
        public void setPos(Vec3 vec) // External setPos function
        {
            playerAABB.AA.x = vec.x;
            playerAABB.BB.x = vec.x + 0.6f;

            playerAABB.AA.y = vec.y;
            playerAABB.BB.y = vec.y + 1.8f;

            playerAABB.AA.z = vec.z;
            playerAABB.BB.z = vec.z + 0.6f;
        }

        public void refreshAABB() // External refreshAABB function
        {
            playerAABB.AA.x = playerAABB.AA.x;
            playerAABB.BB.x = playerAABB.AA.x + 0.6f;

            playerAABB.AA.y = playerAABB.AA.y;
            playerAABB.BB.y = playerAABB.AA.y + 1.8f;

            playerAABB.AA.z = playerAABB.AA.z;
            playerAABB.BB.z = playerAABB.AA.z + 0.6f;
        }

        public Vec3 lookingVec
        { get => MathUtils.directionalVector((bodyRots.x + 89.9f) * (float)Math.PI / 178F, bodyRots.y * (float)Math.PI / 178F); }
        #endregion
    }
}
